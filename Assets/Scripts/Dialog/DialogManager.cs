using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dBox;
    [SerializeField] private TMP_Text dText;
    public bool dialogActive = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && dialogActive == false)
        {
            dialogActive = true;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void CloseBox()
    {
        dialogActive = false;
        dBox.SetActive(false);
    }
}
