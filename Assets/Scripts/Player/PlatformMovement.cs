using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    private Vector2 horizontal;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        MovePlatform();
    }
    float Horizontal()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            return horizontal;
        }
        return 0;
    }
    void MovePlatform()
    {
        Vector2 velocity = new Vector2(Horizontal() * playerSpeed, rb.velocity.y);
        rb.velocity = velocity;
    }
}
