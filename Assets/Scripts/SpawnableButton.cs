using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnableButton : MonoBehaviour
{
    /// <summary>
    /// Componente de Texto del botón
    /// </summary>
    public TextMeshProUGUI nameText;
    /// <summary>
    /// Componente visual del botón
    /// </summary>
    public RawImage image;
    /// <summary>
    /// Prefab que se va spawnear cuando se clicke
    /// </summary>
    public SpawnablePrefab prefabToSpawn;

    public void Start()
    {
        ConfigureUIElement();
    }

    /// <summary>
    /// Función para configurar el botón con los datos del prefab asignado
    /// </summary>
    public void ConfigureUIElement()
    {
        if (prefabToSpawn)
        {
            image.texture = prefabToSpawn.image2d;
            nameText.text = prefabToSpawn.name;
        }

    }
    /// <summary>
    /// Función lanzada al interactuar con el botón, spawneamos el elemento através del Singleton
    /// </summary>
    public void SpawnElement()
    {
        SpawnerManager.Instance.AddNextSpawnableObject(prefabToSpawn.gameObject);

    }

}
