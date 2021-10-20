using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupScript : MonoBehaviour
{
    [SerializeField] private float disappearSpeed = 3f;
    [SerializeField] private float disappearTimer = 1f;
    private Color textColor;
    private TextMeshPro textMesh;
    [SerializeField] private float moveSpeed = 0.5f;

    private void Start()
    {
        textMesh = GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        transform.position += new Vector3(0, moveSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
