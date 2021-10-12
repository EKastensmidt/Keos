using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CameraPixelChange : MonoBehaviour
{
    private PixelPerfectCamera pp;
    [SerializeField] private float pixels;
    private bool isInTrigger = false;

    void Start()
    {
        pp = GameObject.Find("Main Camera").GetComponent<PixelPerfectCamera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Maguito")
        {
            isInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Maguito")
        {
            isInTrigger = false;
        }
    }
    private void FixedUpdate()
    {
        if (isInTrigger && pp.assetsPPU > pixels) pp.assetsPPU--;
        else if (!isInTrigger && pp.assetsPPU < 32) pp.assetsPPU++;
    }
}
