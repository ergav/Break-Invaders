using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour, IDamageable
{
    [SerializeField] int maxHealth;
    [SerializeField] Sprite destroyedSprite;
    [SerializeField] Transform destroyFX;
    bool spriteChanged;
    BuildingList manager;
    int currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void Damage()
    {
        currentHealth--;
        if (!spriteChanged)
        {
            GetComponent<SpriteRenderer>().sprite = destroyedSprite;
            spriteChanged = true;
        }
        if(currentHealth <= 0)
        {
            Transform _destroyFX = Instantiate(destroyFX, transform.position, Quaternion.identity);
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
        if(!collision.gameObject.TryGetComponent(out BallPhysics ball) || collision.gameObject.TryGetComponent(out LaserBeam laser))
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
