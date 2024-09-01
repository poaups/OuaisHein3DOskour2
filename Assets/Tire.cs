using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonoBehaviour
{
    public GameObject Balle;
    public float distanceDevantPlayer = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Calculer la position devant le joueur
            Vector3 _pos = new Vector3(transform.position.x+ 0.30f, transform.position.y + 1.75f, transform.position.z);
            Vector3 positionDevantPlayer = _pos + transform.forward * distanceDevantPlayer;

            // Instancier la balle à cette position
            Instantiate(Balle, positionDevantPlayer, transform.rotation);
        }
    }
}
