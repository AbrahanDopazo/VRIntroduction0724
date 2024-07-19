using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    /// <summary>
    /// Variable Singleton
    /// </summary>
    public static SpawnerManager Instance { get; private set; }

    /// <summary>
    /// Lista ordenada de objetos que se van a spawnear
    /// </summary>
    private List<GameObject> listOfSpawnables = new List<GameObject>();
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Spawnea el obj en la posición indicada
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="newPosition"></param>
    public void AddSpawnObjectInPosition(GameObject obj, Vector3 newPosition)
    {
        GameObject.Instantiate(obj, newPosition, Quaternion.identity);
    }

    /// <summary>
    /// Añade un objeto a la lista para ser spawneado
    /// </summary>
    /// <param name="obj"></param>
    public void AddNextSpawnableObject(GameObject obj)
    {
        listOfSpawnables.Add(obj);
    }

    /// <summary>
    /// Spawnea el primer elemento de la lista y lo elimina
    /// </summary>
    /// <param name="newPosition"></param>
    public void SpawnNextSpawnable(Vector3 newPosition)
    {
        if (listOfSpawnables.Count > 0)
        {
            GameObject.Instantiate(listOfSpawnables[0], newPosition, Quaternion.identity);
            listOfSpawnables.RemoveAt(0);
        }
    }

    public void SpawnTest()
    {
        SpawnNextSpawnable(Camera.main.transform.position + Camera.main.transform.forward * 2f);
    }



}


