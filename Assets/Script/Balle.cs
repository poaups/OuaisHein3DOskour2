using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement de la balle
    private Vector3 initialDirection; // Direction initiale de la balle (lorsqu'elle est tirée)

    void Start()
    {
        // Récupérer la caméra avec le tag "MainCamera"
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");

        if (cameras.Length > 0)
        {
            // Capturer la direction actuelle de la caméra (forward) lors de la création de la balle
            Transform cameraTransform = cameras[0].transform;
            initialDirection = cameraTransform.forward;
        }
        else
        {
            Debug.LogWarning("Aucune caméra trouvée avec le tag 'MainCamera'.");
        }
    }

    void Update()
    {
        // Déplacer la balle dans la direction initiale capturée
        transform.position += initialDirection * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            speed = 0;
        }
    }
}
