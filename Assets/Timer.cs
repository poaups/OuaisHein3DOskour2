using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Durée du Timer en secondes")]
    public float duration; 

    private float timeRemaining; 
    [HideInInspector] public bool isTimerRunning = false; 

    [Header("UI du Timer")]
    public TextMeshProUGUI timerText;

    void Start()
    {
        timeRemaining = duration;
        
    }

    void Update()
    {
        
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
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
    private void UpdateTimerText(float currentTime)
    {
        print(currentTime);
        float seconds = Mathf.FloorToInt(currentTime); // Le reste en secondes
        timerText.text = string.Format("{0:00}", seconds);  // Afficher seulement les secondes
    }

}
