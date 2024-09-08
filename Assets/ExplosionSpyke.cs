using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpyke : MonoBehaviour
{
    public float MaxScale;
    public float SpeedScale;
    void Start()
    {
        
    }
    void Update()
    {
        if(gameObject.transform.localScale.x < MaxScale)
        {
            gameObject.transform.localScale += Vector3.one * SpeedScale * Time.deltaTime;
        }
    }

    
}
