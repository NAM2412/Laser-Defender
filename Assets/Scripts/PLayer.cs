using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PLayer : MonoBehaviour
{
    
    [SerializeField] float moveSpeed = 5f;

    [Header("Padding")]
    [SerializeField] float paddingLeft = 0.5f;
    [SerializeField] float paddingRight = 0.5f;
    [SerializeField] float paddingTop = 5f;
    [SerializeField] float paddingBottom = 2f;
    float bottomLeftPosition = 0f;
    float topRightPosition = 1f;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Shooter shooter;

    void Awake() 
    {
        shooter = GetComponent<Shooter>();
    }
    void Start() 
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    private void InitBounds () // initialling screen boundaries for player
    {
        Camera camera = Camera.main;
        minBounds = camera.ViewportToWorldPoint(new Vector2(bottomLeftPosition,bottomLeftPosition));  
        maxBounds= camera.ViewportToWorldPoint(new Vector2(topRightPosition,topRightPosition));  
    }
    private void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 currentPosition = new Vector2();
        currentPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        currentPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = currentPosition;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
