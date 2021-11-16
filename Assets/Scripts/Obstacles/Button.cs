using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isActivated = false;
    [SerializeField] private float gateMoveAmount = 2f;
    [SerializeField] private bool isOneWay = false;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject gate;
    [SerializeField] private Sprite spriteActivated,spriteDeactivated;
    //Temprary solution
    private Color AColor = Color.green;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteDeactivated = spriteRenderer.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated)
        {
            spriteRenderer.sprite = spriteActivated;
            gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y + gateMoveAmount, gate.transform.position.z);
            isActivated = true;
        }
        else
        {
            if (!isOneWay)
            {
                spriteRenderer.sprite = spriteDeactivated;
                gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y - gateMoveAmount, gate.transform.position.z);
                isActivated = false;

            }   
        }
    }
}
