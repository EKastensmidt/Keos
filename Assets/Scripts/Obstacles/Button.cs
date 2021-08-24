using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool isActivated = false;
    [SerializeField] private GameObject gate;
    //Temprary solution
    private Color AColor = Color.green;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActivated)
        {
            gameObject.GetComponent<SpriteRenderer>().color = AColor;
            gate.transform.position = new Vector3(gate.transform.position.x, gate.transform.position.y + 2f, gate.transform.position.z);
        }
    }
}
