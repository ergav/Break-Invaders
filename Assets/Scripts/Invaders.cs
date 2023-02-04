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

    void Start()
    {
        
    }

    void Update()
    {
        if (movingDown)
        {
            transform.Translate(Vector2.down * movementSpeedVertical * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * movementSpeedHorizontal * Time.deltaTime);
        }

        if ((transform.position.x > sideMoveDistance && movementSpeedHorizontal > 0)|| (transform.position.x < -sideMoveDistance && movementSpeedHorizontal < 0))
        {
            if (!movingDown)
            {
                StartCoroutine(MovingDownTimer());
                movingDown = true;
            }
        }
    }

    public void Death()
    {

    }

    IEnumerator MovingDownTimer()
    {
        yield return new WaitForSeconds(moveDownTime);
        movementSpeedHorizontal = -movementSpeedHorizontal;
        movingDown = false;
    }
}
