using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyShip : MonoBehaviour, IDamageable
{
    [SerializeField] Transform extraBall;
    [SerializeField] float speed;
    [SerializeField] float despawnDistance;
    Vector2 spawnPos;
    private void Awake()
    {
        spawnPos = transform.position;
    }
    public void Damage()
    {
        Transform ball = Instantiate(extraBall, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void Update()
    {
        Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.TryGetComponent(out BallPhysics ball))
        {
            return;
        }
        Damage();
    }
    void Move()
    {
        Vector3 movement = new Vector3(transform.right.x * speed, 0, 0);
        transform.localPosition += movement * Time.deltaTime;
        if(Vector2.SqrMagnitude((Vector2)transform.position - spawnPos) > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
