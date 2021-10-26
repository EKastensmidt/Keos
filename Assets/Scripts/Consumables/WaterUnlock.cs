using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUnlock : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] private GameObject canvasSprite, canvasLetter, endPortal;
    void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            GameManager.skipDialogue = false;
            GameManager.IsWaterUnlocked = true;
            canvasSprite.SetActive(true);
            canvasLetter.SetActive(true);
            endPortal.SetActive(true);
            SoundManagerScript.PlaySound("Consumable");
            Destroy(gameObject);
        }
    }
}
