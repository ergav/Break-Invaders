using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyShipSpawner : MonoBehaviour
{
    [SerializeField] GameObject supplyShip;
    public int kills;
    [HideInInspector]public int killsTen;


    public void AddKill()
    {
        kills++;
        killsTen++;

        if (killsTen == 10)
        {
            killsTen = 0;
            SpawnShip();
        }
    }

    void SpawnShip()
    {
        Instantiate(supplyShip, transform.position, Quaternion.identity);
    }
}
