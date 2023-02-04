using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invaders : MonoBehaviour
{
    [SerializeField] private float movementSpeedVertical;
    [SerializeField] private float movementSpeedHorizontal;
    [SerializeField] private float moveDownTime;
    [SerializeField] private int health = 1;
    bool movingDown;
    [SerializeField] float sideMoveDistance = 6;
    //[SerializeField] Vector2 minBorder;
    //[SerializeField] Vector2 maxBorder;

    [SerializeField] GameObject laser;
    [SerializeField] int shootingOdds = 10;
    [SerializeField] float shootCoolDown = 1;
    bool hasShot;

    SupplyShipSpawner counter;

    void Start()
    {
        counter = FindObjectOfType<SupplyShipSpawner>();
    }

    void Update()
    {
        //Movement
        if (movingDown)
        {
            transform.Translate(Vector2.down * movementSpeedVertical * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * movementSpeedHorizontal * Time.deltaTime);
        }

        //Move down
        if ((transform.position.x > sideMoveDistance && movementSpeedHorizontal > 0)|| (transform.position.x < -sideMoveDistance && movementSpeedHorizontal < 0))
        {
            if (!movingDown)
            {
                StartCoroutine(MovingDownTimer());
                movingDown = true;
            }
        }

        //Health
        if (health <= 0)
        {
            Death();
        }

        //Building detection
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(transform.position, Vector2.down, 100f);
        if (hits.Length == 0)
        {
            return;
        }

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            if (hit.collider.gameObject.tag == "Building")
            {
                if (!hasShot)
                {
                    hasShot = true;
                    ShootLaser();
                    StartCoroutine(ShootCoolDownTimer());
                }
                return;
            }
        }
    }

    public void Death()
    {
        if (counter != null)
        {
            counter.AddKill();
        }

        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

    }

    public void ShootLaser()
    {
        Debug.Log("EYY!");
        int rng = Random.Range(0, shootingOdds);
        if (rng == 1)
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            TakeDamage(1);
        }
    }

    IEnumerator MovingDownTimer()
    {
        yield return new WaitForSeconds(moveDownTime);
        movementSpeedHorizontal = -movementSpeedHorizontal;
        movingDown = false;
    }

    IEnumerator ShootCoolDownTimer()
    {
        yield return new WaitForSeconds(shootCoolDown);
        hasShot = false;
    }
}