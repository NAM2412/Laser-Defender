using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayer : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }
}
