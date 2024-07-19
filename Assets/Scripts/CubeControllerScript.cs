using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControllerScript : MonoBehaviour
{
    public Camera sceneCamera;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    public float step = 5f;
    public float rotationSpeed = 5f;
    public float distanceToCamera = 3f;

    // Colocamos este GameObject 3m delante de la c�mara
    void Start()
    {
        transform.position = sceneCamera.transform.position + sceneCamera.transform.forward * distanceToCamera;
    }
    /// <summary>
    /// Funci�n para recolocar este GameObject 3m delante de la c�mara y con la rotaci�n viendo a la c�mara
    /// </summary>
    void centerCube()
    {
        targetPosition = sceneCamera.transform.position + sceneCamera.transform.forward * distanceToCamera;
        targetRotation = Quaternion.LookRotation(transform.position - sceneCamera.transform.position);

        transform.position = Vector3.Lerp(transform.position, targetPosition, step * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step * Time.deltaTime);
    }


    /// <summary>
    /// Funci�n que se llama en cada frame y en la controlamos los eventos que han llegado de los mandos
    /// </summary>
    private void Update()
    {
        //Gatillo del controlador derecho
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
            centerCube();
        // Almacenamos el valor x del Joystyick para usar como velociad de rotaci�n
        float xRotation = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
        float yRotation = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;
        transform.Rotate(yRotation * rotationSpeed * step * Time.deltaTime, xRotation * rotationSpeed * step * Time.deltaTime, 0);
        //Si pulsamos el bot�n A se acercar� a la c�mara
        if (OVRInput.Get(OVRInput.RawButton.A))
        {
            distanceToCamera -= 0.2f;
            centerCube();
        }
        // Si pulsamos el bot�n B se alejar� de la c�mara
        if (OVRInput.Get(OVRInput.RawButton.B))
        {
            distanceToCamera += 0.2f;
            centerCube();
        }
    }
}



