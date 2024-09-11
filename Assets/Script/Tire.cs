using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tire : MonoBehaviour
{
    [Header("Référence")]
    public GameObject Balle;
    public GameObject Knife;
    public GameObject Phantom;

    [Header("Ui")]
    public Image KnifeUi;
    public Image PhantomUi;

    [Header("Paramètre")]
    public float distanceDevantPlayer = 1f;

    // Variables pour sauvegarder les vitesses de mouvement
    private float _moveSpeedSave;
    private float _moveSpeedLimitUp;

    void Start()
    {
        _moveSpeedSave = gameObject.GetComponent<SimpleMovement>()._moveSpeedSave;
        _moveSpeedLimitUp = gameObject.GetComponent<SimpleMovement>().movespedLimitUp;

        Knife.SetActive(false);

        SetUITransparency(KnifeUi, 0.5f);  
    }

    void Update()
    {
        float _mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetKeyDown(KeyCode.Mouse0) && Phantom.activeSelf == true)
        {
            // Calculer la position devant le joueur
            Vector3 _pos = new Vector3(transform.position.x + 0.30f, transform.position.y + 1.75f, transform.position.z);
            Vector3 positionDevantPlayer = _pos + transform.forward * distanceDevantPlayer;
            Instantiate(Balle, positionDevantPlayer, transform.rotation);
        }

        // Si la molette de la souris est tournée vers le haut
        if (_mouseScroll > 0f)
        {
            // Restaurer la vitesse de mouvement
            gameObject.GetComponent<SimpleMovement>().moveSpeed = _moveSpeedSave;

  
            Phantom.SetActive(true);
            Knife.SetActive(false);

            
            SetUITransparency(PhantomUi, 1f); 
            SetUITransparency(KnifeUi, 0.50f); 
        }
        // Si la molette de la souris est tournée vers le bas
        else if (_mouseScroll < 0f)
        {
          
            gameObject.GetComponent<SimpleMovement>().moveSpeed = _moveSpeedLimitUp;

            Knife.SetActive(true);
            Phantom.SetActive(false);

            SetUITransparency(PhantomUi, 0.5f);
            SetUITransparency(KnifeUi, 1f);
        }
    }

    void SetUITransparency(Image uiImage, float alphaValue)
    {
        Color tempColor = uiImage.color;
        tempColor.a = alphaValue; 
        uiImage.color = tempColor;
    }

    public void DisableWeapons()
    {
        Phantom.SetActive(false);
        Knife.SetActive(false);
    }
}
