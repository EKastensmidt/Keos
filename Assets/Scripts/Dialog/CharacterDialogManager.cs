using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;



public class CharacterDialogManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Image nameSprite;
    public TMP_Text dialogueText;
    public Animator animator;

    private bool isInDialogue;
    private AudioSource audioSource;

    public bool IsInDialogue { get => isInDialogue; set => isInDialogue = value; }

    void Start()
    {
        sentences = new Queue<string>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartDialogue (Dialog dialog)
    {
        isInDialogue = true;
        animator.SetBool("IsOpen", true);

        nameSprite.sprite = dialog.characterSprite;

        sentences.Clear();
        foreach (var sentece in dialog.sentences)
        {
            sentences.Enqueue(sentece);
        }
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        audioSource.Play();
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        audioSource.Stop();
    }

    private void EndDialogue()
    {
        isInDialogue = false;
        animator.SetBool("IsOpen", false);
    }
}
