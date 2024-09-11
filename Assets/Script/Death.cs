using TMPro;
using UnityEngine;
using System.Collections;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Death : MonoBehaviour
{
    public Camera CameraFps;
    public float Speedfade = 1.0f; // Valeur par défaut pour la vitesse de fade
    public TextMeshProUGUI YourDeadTxt;
    private Animator _animator2;
    [HideInInspector] public bool IsDeath = false;

    private bool isFading = false; // Pour éviter de lancer plusieurs fades en même temps

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
    //Exécution sur plusieurs frames : Une coroutine permet d'exécuter des actions progressivement sur plusieurs frames. Contrairement
    //à une boucle while classique dans une méthode normale, qui bloquerait tout le jeu jusqu'à ce qu'elle soit terminée, une coroutine continue de s'exécuter sans bloquer les autres parties du jeu.

}
