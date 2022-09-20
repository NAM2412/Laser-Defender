using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreOfKill = 50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;


    void Awake() 
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public int GetHealth() 
    {
        return health;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>(); // lấy damageDealer ở trong hub
        if (damageDealer != null) // nếu không lấy được damageDealer
        {
            TakingDamage(damageDealer.Damage);
            PlayHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamgeClip();
            damageDealer.Hit();

        }
    }

    private void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
        {
            cameraShake.PLay();
        }
    }

    private void TakingDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GotKilled();
        }
    }

    private void GotKilled()
    {
        if (!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreOfKill);
        }
        Destroy(gameObject);
    }

    private void PlayHitEffect () 
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
