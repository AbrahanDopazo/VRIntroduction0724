using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnableButton : MonoBehaviour
{
    /// <summary>
    /// Componente de Texto del bot�n
    /// </summary>
    public TextMeshProUGUI nameText;
    /// <summary>
    /// Componente visual del bot�n
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
    /// Funci�n para configurar el bot�n con los datos del prefab asignado
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
    /// Funci�n lanzada al interactuar con el bot�n, spawneamos el elemento atrav�s del Singleton
    /// </summary>
    public void SpawnElement()
    {
        SpawnerManager.Instance.AddNextSpawnableObject(prefabToSpawn.gameObject);

    }

}
