using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)]float shootingVolume = 1f;

    [Header("Damaging")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f,1f)]float damageVolume = 1f;


    private void PLayClip(AudioClip clip, float clipVolume) 
    {
        if (clip != null)
        {
            Vector3 cameraPos= Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos,clipVolume);
        }
    }
    public void PlayShootingClip() 
    {
        PLayClip(shootingClip,shootingVolume);
    }

    public void PlayDamgeClip() 
    {
        PLayClip(damageClip,damageVolume);
    }
}
