using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingList : MonoBehaviour
{
    [SerializeField] int buildingsToSpawn;
    [SerializeField] float spawnPositionIncrement;
    [SerializeField] Vector2 spawnStartPosition;
    [SerializeField] Building buildingPrefab;
    List<Building> buildingsList = new List<Building>();
    private void Awake()
    {
        SpawnBuildings();
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
    void SpawnBuildings()
    {
        for (int i = 0; i < buildingsToSpawn; i++)
        {
            Building newBuilding = Instantiate(buildingPrefab);
            Vector2 positionToSpawn = spawnStartPosition + (Vector2.right * spawnPositionIncrement) * i;
            newBuilding.transform.localPosition = positionToSpawn;
            buildingsList.Add(newBuilding);
        }
    }
    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
