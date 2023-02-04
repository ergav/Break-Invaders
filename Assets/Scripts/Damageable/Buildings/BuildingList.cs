using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingList : MonoBehaviour
{
    [SerializeField] List<Building> buildingsList;
    private void Awake()
    {
        foreach (Building building in buildingsList)
        {
            building.Initialize(this);
        }
    }
    public void RemoveFromList(Building buildingToRemove)
    {
        buildingsList.Remove(buildingToRemove);
        if(buildingsList.Count <= 0)
        {
            Reset();
        }
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
