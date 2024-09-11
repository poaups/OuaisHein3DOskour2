using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall : MonoBehaviour
{
    List<Vector3> _pos = new List<Vector3>();
    public GameObject _maprefab;
    private bool _oui = true;
    private bool _isRecalling = false; // Pour vérifier si la coroutine est déjà en cours
    private int _index = 0;

    void Start()
    {

    }

    void Update()
    {
        print(transform.position + " pos pas recall");

        if (_pos.Count <= 300)
        {
            _pos.Add(transform.position);
            print(_pos);
        }
        else if (_oui && !_isRecalling) // Démarre la coroutine si elle n'est pas déjà en cours
        {
            StartCoroutine(RecallFunction());
            _oui = false; // Empêche de relancer la coroutine
        }
    }

    IEnumerator RecallFunction()
    {
        _isRecalling = true; // Indique que la coroutine est en cours

        while (_index < _pos.Count)
        {
            // Spawn la sphère toutes les 0.5 secondes
            if (_index % 10 == 0)
            {
                Instantiate(_maprefab, _pos[_index], Quaternion.identity);
                transform.position = _pos[_index];
            }

            _index++;
            yield return new WaitForSeconds(0.01f);
        }

        _isRecalling = false; // Indique que la coroutine est terminée
    }
}