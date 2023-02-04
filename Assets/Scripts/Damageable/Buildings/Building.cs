using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    BuildingList manager;
    int currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Damage()
    {
        currentHealth--;
        if(currentHealth <= 0)
        {
            manager.RemoveFromList(this);
            Destroy(gameObject);
        }
    }
    public void Initialize(BuildingList manager)
    {
        this.manager = manager;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.TryGetComponent(out BallPhysics ball))
        {
            return;
        }
        if (ball.IsExtraBall)
        {
            return;
        }
        Damage();
    }
}
