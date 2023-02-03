using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    
    [SerializeField] float maxVelocity;
    [SerializeField] float ballVelocity;
    private Rigidbody2D rb;
    const float minRandomForceX = -8;
    const float maxRandomForceX = 8;
    [SerializeField] float platformBounceX;
    [SerializeField] float platformBounceY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomForce();
    }
    private void Update()
    {
        LimitVelocity();
    }
    void RandomForce()
    {
        float randomXPush = Random.Range(minRandomForceX, maxRandomForceX);
        Vector2 force = new Vector2(randomXPush, -ballVelocity);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    void LimitVelocity()
    {
        if(rb.velocity.magnitude >= maxVelocity)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detect collision of platform
        if(!collision.gameObject.TryGetComponent(out PlatformMovement platform))
        {
            return;
        }
        Debug.Log("Bounce");
        Vector2 platformCenter = platform.transform.position;
        Vector2 ballPosition = transform.position;
        float xDifference = platformCenter.x - ballPosition.x;
        float xBounce = xDifference * platformBounceX;
        Vector2 bounceVector = new Vector2(xBounce, platformBounceY);
        rb.AddForce(bounceVector, ForceMode2D.Impulse);
    }
}
