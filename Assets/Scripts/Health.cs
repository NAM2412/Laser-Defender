using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>(); // lấy damageDealer ở trong hub
        if (damageDealer != null) // nếu không lấy được damageDealer
        {
            TakingDamage(damageDealer.Damage);
            damageDealer.Hit();
        }
    }

    private void TakingDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
