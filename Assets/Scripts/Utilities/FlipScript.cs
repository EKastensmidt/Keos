using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float flipRate = 1;
    private float flipCd;
    private bool flag = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (flipCd <= Time.time)
        {
            if (flag) flag = false;
            else flag = true;
            spriteRenderer.flipX = flag;
            flipCd = flipRate + Time.time;
        }
    }
}
