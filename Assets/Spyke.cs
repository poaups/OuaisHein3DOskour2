using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spyke : MonoBehaviour
{
    public Slider ChargementSpyke;

    [Header("Paramètres")]
    public float Timer;
    public GameObject SpykeToPlant;
    public float zOffset = 10f;
    public GameObject ExplosionSpyke;

    public Timer timer;  // Référence vers le script Timer

    void Start()
    {
        ChargementSpyke.gameObject.SetActive(false);
        ChargementSpyke.value = 0;
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.O))
        {
            ChargementSpyke.gameObject.SetActive(true);
            StartCoroutine(PlatingSpyke());
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            ChargementSpyke.gameObject.SetActive(false);
            ChargementSpyke.value = 0;
            StopAllCoroutines();
        }
    }

    IEnumerator PlatingSpyke()
    {
        float elapsedTime = 0f;
        ChargementSpyke.maxValue = Timer;

        while (elapsedTime < Timer)
        {
            elapsedTime += Time.deltaTime;
            ChargementSpyke.value = elapsedTime;
            yield return null;
        }

        Vector3 spawnPosition = transform.position + transform.forward * zOffset;
        Instantiate(SpykeToPlant, spawnPosition, Quaternion.identity);
        timer.isTimerRunning = true;
        timer.gameObject.SetActive(true);

        ChargementSpyke.value = 0;
        ChargementSpyke.gameObject.SetActive(false);
        
    }

    public void MacronExplosion()
    {
        var test = GameObject.Find("Spyke(Clone)");
        Instantiate(ExplosionSpyke, test.transform.position,Quaternion.identity);;
    }
    void OnTriggerEnter(Collider collision)
    {
        print(collision + "colision");
        if (collision.gameObject.name == "ExplosionSyke(Clone)")
        {
            print("mort");
        }
    }
}
