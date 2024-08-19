using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationSouris : MonoBehaviour
{
    //ce script fonctionne avec "SimpleMovement"

    [Header("Look Parameters")]
    [SerializeField, Range(1, 10)] private float lookSpeedX = 1.5f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 1.5f;
    [SerializeField, Range(-180, 1)] private float upperLooklimit = -80.0f;
    [SerializeField, Range(1, 180)] private float lowerLooklimit = 80.0f;

    private Camera playerCamera;
    private float rotationX = 0;
    private float rotationY = 0;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Cache le curseur et le verrouille au centre de l'écran
        Cursor.visible = false; // Rendre le curseur invisible
    }

    void Update()
    {
        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        // Récupère le mouvement de la souris
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Calculer les nouvelles rotations
        rotationX -= mouseY * lookSpeedY;
        rotationY += mouseX * lookSpeedX;

        // Limiter la rotation verticale
        rotationX = Mathf.Clamp(rotationX, upperLooklimit, lowerLooklimit);

        // Appliquer la rotation à la caméra
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Appliquer la rotation horizontale au joueur
        // Le joueur devrait tourner horizontalement pour suivre la caméra
        transform.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
