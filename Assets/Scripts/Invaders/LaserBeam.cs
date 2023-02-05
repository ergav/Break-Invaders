using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public float speed = 3;

    public LayerMask destructible;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Building>(out Building building))
        {
            building.Damage();
        }
        else if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
