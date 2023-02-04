using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float maxLeft, maxRight;
    public Action OnPlatformDestroyed;
    private Vector2 horizontal;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlatform();
        LimitMovement();
    }
    float Horizontal()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        return horizontal;
    }
    void MovePlatform()
    {
        Vector2 velocity = new Vector2(Horizontal() * playerSpeed, rb.velocity.y);
        rb.velocity = velocity;
    }
    void LimitMovement()
    {
        if(Horizontal() == 0)
        {
            return;
        }
        if (transform.position.x <= maxLeft && Horizontal() < 0)
        {
            transform.position = new Vector2(maxLeft, transform.position.y);
        }
        if (transform.position.x >= maxRight && Horizontal() > 0)
        {
            transform.position = new Vector2(maxRight, transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Invaders invaders))
        {
            OnPlatformDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
