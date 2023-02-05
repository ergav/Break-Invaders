using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] float returnTime = 5;

    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(returnTime);
        Destroy(gameObject);
    }
}
