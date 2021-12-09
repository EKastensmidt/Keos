using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossW3 : Enemy
{
    [SerializeField] private GameObject projectileAttack, groundAttack;
    [SerializeField] private ParticleSystem particleAttackSystem;

    [SerializeField] private float attackTimer;

    private bool isParticleAttackActive = false;

    private float attackTimerAux;
    private GameObject _player;

    private int _currentAttack;

    void Start()
    {
        _player = GameObject.Find("Maguito");
        particleAttackSystem.Stop();
        attackTimerAux = attackTimer;
        _currentAttack = 2;
    }

    public override void Update()
    {
        if (BossFight3Enter.IsStarted)
        {
            ActivateAttack(_currentAttack);

            if (attackTimer < 0)
            {
                NextAttack();
            }
            attackTimer -= Time.deltaTime;
        }
    }

    private void NextAttack()
    {
        int randomNumber = Random.Range(1, 4);
        if(randomNumber != _currentAttack)
        {
            DisableAttack(_currentAttack);
            _currentAttack = randomNumber;
            attackTimer = attackTimerAux;
        }     
    }

    private void ActivateAttack(int currentAttack)
    {
        switch (currentAttack)
        {
            case 1:
                if (particleAttackSystem.isPlaying) { }
                else
                    particleAttackSystem.Play();
                break;
            case 2:
                projectileAttack.SetActive(true);
                break;
            case 3:
                groundAttack.SetActive(true);
                break;
        }
    }

    private void DisableAttack(int currentAttack)
    {
        switch (currentAttack)
        {
            case 1:
                if (particleAttackSystem.isStopped) { }
                else
                    particleAttackSystem.Stop();
                break;
            case 2:
                projectileAttack.SetActive(false);
                break;
            case 3:
                groundAttack.SetActive(false);
                break;
        }
    }
}
