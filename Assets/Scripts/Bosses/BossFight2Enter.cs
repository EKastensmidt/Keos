using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight2Enter : MonoBehaviour
{
    private GameObject Boss;
    private Vector2 position;
    private bool isEntered = false;
    [SerializeField] private GameObject BGMusic, sawBlades;

    public bool IsEntered { get => isEntered; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isEntered = true;
    }

    public void QueueObjects()
    {
        BGMusic.SetActive(true);
        sawBlades.SetActive(true);
    }
}
