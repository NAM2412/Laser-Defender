using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int Damage { get => damage; set => damage = value; }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
