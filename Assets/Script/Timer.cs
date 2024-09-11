using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Spyke _spyke;
    [Header("Durée du Timer en secondes")]
    public float duration; 

    private float timeRemaining; 
    [HideInInspector] public bool isTimerRunning = false; 

    [Header("UI du Timer")]
    public TextMeshProUGUI timerText;

    void Start()
    {
        gameObject.SetActive(false);
        timeRemaining = duration;
        
    }

    void Update()
    {
        
        if (isTimerRunning)
        {
            if (timeRemaining >= 0)
            {
                // Décrémenter le temps restant
                timeRemaining -= Time.deltaTime;
                // Mettre à jour le texte du timer
                UpdateTimerText(timeRemaining);
            }
            else
            {
                // Arrêter le timer lorsque le temps est écoulé
                timeRemaining = 0;
                isTimerRunning = false;
                print("Timer terminé !");
            }
        }
    }

    // Démarrer le timer
    public void StartTimer()
    {
        
        print("StartTimer");
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
        gameObject.SetActive(false);
    }
    private void UpdateTimerText(float currentTime)
    {
        float seconds = Mathf.FloorToInt(currentTime); // Le reste en secondes
        if(seconds < 0)
        {
            seconds = 0;
            isTimerRunning = false;
            gameObject.SetActive(false);
            _spyke.MacronExplosion();
        }

        timerText.text = string.Format("{0:00}", seconds);  // Afficher seulement les secondes
    }

}
