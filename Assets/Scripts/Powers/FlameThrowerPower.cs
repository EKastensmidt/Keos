﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerPower : MonoBehaviour
{
    private PlayerController _playerController;
<<<<<<< HEAD
=======
    private float hitCd;
    private float hitRate = 0.1f;

>>>>>>> parent of d9aff8e (hit detection fix & enemies)
    private void Start()
    {
        _playerController = GameObject.Find("Maguito").GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        if (!_playerController.IsPlaying)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
<<<<<<< HEAD
        return Mathf.Atan2(b.y - a.y, b.x - a.x) * Mathf.Rad2Deg;
=======
        if (other.layer == 10)
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (hitCd <= Time.time)
            {
                enemy.CurrHealth -= Damage;
                hitCd = Time.time + hitRate;
            }
        }
>>>>>>> parent of d9aff8e (hit detection fix & enemies)
    }
}
