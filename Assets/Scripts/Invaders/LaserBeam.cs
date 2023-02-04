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
        if (collision.tag == "Building")
        {
            Building building = collision.gameObject.GetComponent<Building>();
            building.Damage();
            Destroy(gameObject);
        }
        else if (collision.tag != "Enemy")
        {
            Destroy(gameObject);
        }

    }
}
