using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialoge;
    public void TriggerDialogue()
    {
        FindObjectOfType<CharacterDialogManager>().StartDialogue(dialoge);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.skipDialogue)
            return;

        if (collision.gameObject.name != "Maguito")
            return;

        TriggerDialogue();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(this);
    }


}
