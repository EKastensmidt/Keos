using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    [SerializeField] private string dialogue;
    [SerializeField] private bool needsF;
    private DialogManager dHolder;
    private GameObject maguito;
    private GameObject fButton;

    private void Start()
    {
        dHolder = FindObjectOfType<DialogManager>();
        maguito = GameObject.Find("Maguito");
        fButton = GetChildWithName(maguito, "FButton");
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Maguito")
        {
            if (!needsF)
            {
                dHolder.ShowBox(dialogue);
            }
            else
            {
                fButton.SetActive(true);
                if (dHolder.dialogActive)
                {
                    dHolder.ShowBox(dialogue);
                    fButton.SetActive(false);
                }
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (dHolder.dialogActive)
        {
            dHolder.ShowBox(dialogue);
            fButton.SetActive(false);
        }     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        dHolder.dialogActive = false;
        fButton.SetActive(false);
        dHolder.CloseBox();
    }

    private GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
}
