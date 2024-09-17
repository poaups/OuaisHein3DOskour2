using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement de la balle
    private Vector3 initialDirection; // Direction initiale de la balle (lorsqu'elle est tir�e)

    void Start()
    {
        // R�cup�rer la cam�ra avec le tag "MainCamera"
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");

        if (cameras.Length > 0)
        {
            // Capturer la direction actuelle de la cam�ra (forward) lors de la cr�ation de la balle
            Transform cameraTransform = cameras[0].transform;
            initialDirection = cameraTransform.forward;
        }
        else
        {
            Debug.LogWarning("Aucune cam�ra trouv�e avec le tag 'MainCamera'.");
        }
    }

    void Update()
    {
        // D�placer la balle dans la direction initiale captur�e
        transform.position += initialDirection * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            speed = 0;
        }
    }
}
