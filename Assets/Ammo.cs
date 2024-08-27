using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float AmmoSpeed;
    public GameObject Weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Vector3 movement = direction * AmmoSpeed * Time.deltaTime;
        transform.position += movement;



        //Vector3.forward = transform.forward + AmmoSpeed * Time.deltaTime;
        //this.transform.position = new Vector3(this.transform.position.x , this.transform.position.y, this.transform.position.z );
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Destroy(this);
        }
    }
}
