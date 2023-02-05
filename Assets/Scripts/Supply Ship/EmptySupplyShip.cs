using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EmptySupplyShip : MonoBehaviour
{
    [SerializeField] float horizontalSpeed = 2;
    [SerializeField] float verticalSpeed = 1;

    [SerializeField] float timeToDespawn;

    private void Awake()
    {
        StartCoroutine(Despawn());
    }
    void Update()
    {
        transform.Translate(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, 0);
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(timeToDespawn);
        Destroy(gameObject);
    }
}
