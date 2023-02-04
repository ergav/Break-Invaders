using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    
    [SerializeField] float maxVelocity;
    [SerializeField] float startVelocity;
    private Rigidbody2D rb;
    const float minRandomForceX = -8;
    const float maxRandomForceX = 8;
    const float minYVelocity = 0.5f;
    [SerializeField] float platformBounceX;
    [SerializeField] float platformBounceY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartForce();
    }
    private void Update()
    {
        LimitVelocity();
        PreventFlatVelocity();
    }
    void StartForce()
    {
        Vector2 force = new Vector2(rb.velocity.x, -startVelocity);
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    void LimitVelocity()
    {
        if(rb.velocity.magnitude >= maxVelocity || rb.velocity.magnitude <= maxVelocity)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    void PreventFlatVelocity()
    {
        float yVelocity = Mathf.Abs(rb.velocity.y);
        if(yVelocity > minYVelocity)
        {
            return;
        }
        float randomYForce = Random.Range(-1f, 1f);
        Vector2 RandomForce = new Vector2(rb.velocity.x, randomYForce);
        rb.AddForce(RandomForce, ForceMode2D.Impulse);
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
