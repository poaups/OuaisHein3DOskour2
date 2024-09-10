using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Camera CameraFps;
    private Animator _animator2;
    [HideInInspector] public bool IsDeath = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator2 = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsDeath = true;
            
        }
        Death2();
    }

    public void Death2()
    {
        if (IsDeath)
        {
            var orientationScript = GetComponent<OrientationSouris>();
            var TireScript = GetComponent<Tire>();
            var CameraScript = GetComponent<CameraSwitch>();
            var SimpleMovement = GetComponent<SimpleMovement>();

            TireScript.DisableWeapons();
            //CameraScript.SwitchCamera();
            SimpleMovement.CanMove = false;
            TireScript.enabled = false;
            orientationScript.enabled = false;

            CameraFps.gameObject.SetActive(false);



            _animator2.SetBool("IsDeathing", true);

        }
    }
}
