using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyShip : MonoBehaviour, IDamageable
{
    public Action OnSpawn;
    public Action OnDestroy;
    [SerializeField] Transform extraBall;
    [SerializeField] float speed;
    [SerializeField] float timeToDespawn;
    float timeAlive;
    Vector2 spawnPos;
    private void Awake()
    {
        spawnPos = transform.position;
        OnSpawn?.Invoke();
    }
    public void Damage()
    {
        Transform ball = Instantiate(extraBall, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void Update()
    {
        Move();
        Timer();
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
    }
    void Timer()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive >= timeToDespawn)
        {
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }
}
