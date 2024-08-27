using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Maprefab;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("Mouse0");
            ShootAmmo();
        }
       
        
    }

    public void ShootAmmo()
    {
        GameObject instance = Instantiate(Maprefab, new Vector3(this.transform.position.x, this.transform.position.y + 0.30f, this.transform.position.z + 0.75f), Maprefab.transform.rotation);

        //Parce que la prefab spawn avec les mauvaises rotation
        instance.transform.localScale = Maprefab.transform.localScale;
    }
}
