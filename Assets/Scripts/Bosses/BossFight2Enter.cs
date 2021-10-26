using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight2Enter : MonoBehaviour
{
    private BossW2 boss;
    private Vector2 position;
    private bool isEntered = false;
    [SerializeField] private GameObject BGMusic, sawBlades;

    public bool IsEntered { get => isEntered; }

    private void Start()
    {
        boss = GameObject.Find("BOSS2").GetComponent<BossW2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.skipDialogue)
            boss.IsFirstPhase = true;

        isEntered = true;
    }

    public void QueueObjects()
    {
        BGMusic.SetActive(true);
        sawBlades.SetActive(true);
    }
}
