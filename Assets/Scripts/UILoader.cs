using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoader : MonoBehaviour
{   /// <summary>
    /// Container donde vamos a spawnear los uiPrefab
    /// </summary>
    public Transform container;
    /// <summary>
    /// Prefab que representar� cada elemento spawneado
    /// </summary>
    public SpawnableButton uiPrefabToSpawn;
    /// <summary>
    /// Lista de Elementos que queremos a�adir a la interfaz para spawnear
    /// </summary>
    public List<SpawnablePrefab> listOfSpawned = new List<SpawnablePrefab>();
    /// <summary>
    /// Funci�n que inicia la construcci�n de la interfaz con los elementos de la lista
    /// </summary>
    public void BuildUI()
    {
        for (int i = 0; i < listOfSpawned.Count; i++)
        {
            SpawnableButton go = Instantiate(uiPrefabToSpawn, container);
            go.prefabToSpawn = listOfSpawned[i];
            go.ConfigureUIElement();
        }
    }

    private void Start()
    {
        BuildUI();
    }


}


