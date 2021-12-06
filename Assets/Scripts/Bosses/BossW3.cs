using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossW3 : Enemy
{
    [SerializeField] private GameObject particleAttack, projectileAttack;
    [SerializeField] private float attackTimer;
    private float attackTimerAux;
    private GameObject _player;

    private int _currentAttack;
    void Start()
    {
        _player = GameObject.Find("Maguito");
        attackTimerAux = attackTimer;
        _currentAttack = 1;
    }

    public override void Update()
    {
        ActivateAttack(_currentAttack);

        if (attackTimer < 0)
        {
            NextAttack();
        }
        attackTimer -= Time.deltaTime;
    }

    private void NextAttack()
    {
        int randomNumber = Random.Range(1, 4);
        if(randomNumber != _currentAttack)
        {
            _currentAttack = randomNumber;
            attackTimer = attackTimerAux;
        }     
    }

    private void ActivateAttack(int currentAttack)
    {
        switch (currentAttack)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}
