using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime =5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;
    [SerializeField] bool useAI;
    [HideInInspector] public bool isFiring;
    
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        audioPlayer =FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
       if(useAI)
       {
            isFiring = true;
       }
    }

    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
       
    }
    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);

            Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();
            if (rigidbody != null)
            {
                rigidbody.velocity = transform.up * projectileSpeed;
            }
            audioPlayer.PlayShootingClip();
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(GetTimeToNextProjectile()); 
        }
    }

    public float GetTimeToNextProjectile()
    {
        float firingRateTime = UnityEngine.Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
        return Mathf.Clamp(firingRateTime,minimumFiringRate, float.MaxValue);
    }
}
