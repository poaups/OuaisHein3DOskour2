using TMPro;
using UnityEngine;
using System.Collections;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Death : MonoBehaviour
{
    public Camera CameraFps;
    public float Speedfade = 1.0f; // Valeur par d�faut pour la vitesse de fade
    public TextMeshProUGUI YourDeadTxt;
    private Animator _animator2;
    [HideInInspector] public bool IsDeath = false;

    private bool isFading = false; // Pour �viter de lancer plusieurs fades en m�me temps

    void Start()
    {
        _animator2 = GetComponent<Animator>();
    }

    void Update()
    {
        Death2();
    }

    public void Death2()
    {
       
        if (IsDeath)
        {
            IsDeath = false;
            StartCoroutine(FadeTextIn());
            var orientationScript = GetComponent<OrientationSouris>();
            var TireScript = GetComponent<Tire>();
            var CameraScript = GetComponent<CameraSwitch>();
            var SimpleMovement = GetComponent<SimpleMovement>();

            TireScript.DisableWeapons();
            SimpleMovement.CanMove = false;
            TireScript.enabled = false;
            orientationScript.enabled = false;

            CameraFps.gameObject.SetActive(false);

            _animator2.SetBool("IsDeathing", true);
        }
    }

    
    private IEnumerator FadeTextIn()
    {
        isFading = true;
        Color color = YourDeadTxt.color;
        color.a = 0f; 
        YourDeadTxt.color = color;

        while (color.a < 1f) 
        {
            color.a += Speedfade * Time.deltaTime; 
            YourDeadTxt.color = color;

            yield return null; 
        }

        color.a = 1f; 
        YourDeadTxt.color = color;

        isFading = false;
    }

    //Pourquoi utiliser une coroutine et pas while ?
    //Ex�cution sur plusieurs frames : Une coroutine permet d'ex�cuter des actions progressivement sur plusieurs frames. Contrairement
    //� une boucle while classique dans une m�thode normale, qui bloquerait tout le jeu jusqu'� ce qu'elle soit termin�e, une coroutine continue de s'ex�cuter sans bloquer les autres parties du jeu.

}
