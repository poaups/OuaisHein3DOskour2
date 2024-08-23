using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spyke : MonoBehaviour
{
    private bool _iswaiting;
    private float _timer = 0f;

    public float Timer;
    public GameObject SpykeToPlant;
    public float zOffset = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(PlatingSpyke());
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            StopAllCoroutines();
        }
    }

    IEnumerator PlatingSpyke()
    {
        yield return new WaitForSeconds(Timer);
        print("Fin timer");

        // Calculer la position d'apparition devant le joueur
        //transform.forward = (0,0,1) 1 max, donc * zOffset (10), transform.forward = (0,0,10)
        //Imaginons transform.position = (22,53,30) + (0,0,10) = (22,53,40)
        Vector3 spawnPosition = transform.position + transform.forward * zOffset;

        Instantiate(SpykeToPlant, spawnPosition, Quaternion.identity);
    }
}
