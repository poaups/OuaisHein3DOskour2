using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera CameraFps;
    public Camera CameraDeath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape))
        //{
        //    CameraFps.gameObject.SetActive(false);
        //}
    }

    public void SwitchCamera()
    {
        CameraFps.gameObject.SetActive(false);
    }
}
