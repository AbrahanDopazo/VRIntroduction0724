using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTableElemetn : MonoBehaviour
{  /// <summary>
   /// Desplazamiento añadido al eje Y para que aparezca por encima del punto escogido
   /// </summary>
    public float heightShift = 2f;
    /// <summary>
    /// Función enviada por el Pointable Unity Event de que se ha interactuado con este cubo, llama al singleton de SpawnerManager para que aparezca el siguiente elemento en la lista
    /// </summary>
    /// <param name="pointerEvent"></param>
    public void InteractwithTable(PointerEvent pointerEvent)
    {
        SpawnerManager.Instance.SpawnNextSpawnable(pointerEvent.Pose.position + new Vector3(0, heightShift, 0));
    }
}
