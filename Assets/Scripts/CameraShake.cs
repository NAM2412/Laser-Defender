using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f; // how far camera can move

    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    public void PLay () 
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float elapsedTime = 0;
        while( elapsedTime < shakeDuration) 
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
            
        }
        transform.position = initialPosition;
        

    }
}
