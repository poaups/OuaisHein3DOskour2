using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement de la balle

    // Update is called once per frame
    void Update()
    {
        // Déplacer la balle sur l'axe Z
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
