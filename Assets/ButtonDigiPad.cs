using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ButtonDigiPad : MonoBehaviour
{
    [Header("Parametre")]
    public GameObject Manager;
    public GameObject _text3d;

    public int Number;
    private float _timeButton;
    private float _DeplacementRange;

    [Header("Type de bouton")]
    public bool Reset;
    public bool Validation;

    [HideInInspector] public bool MouseClickPressed = false;

    private Vector3 _saveposition;
    private bool _isMoving = false;
    private bool _isMovingBack = false;


    public void Awake()
    {
        var _buttonManager = Manager.GetComponent<ButtonManager>();
        _timeButton = _buttonManager.TimeButton2;
        _DeplacementRange = _buttonManager.Deplacement;
        _text3d = _buttonManager.Text3d;
        _saveposition = transform.position;
    }

    void Update()
    {
        if (MouseClickPressed && !_isMoving && transform.position == _saveposition)
        {
            StopAllCoroutines();
            StartCoroutine(Movement());
            print(Number);
            MouseClickPressed = false;
        }

        if (Input.GetKeyDown(KeyCode.O) && !_isMovingBack)
        {
            StopAllCoroutines();
            StartCoroutine(MovementBack());
        }
    }

    IEnumerator Movement()
    {
        RestCode();

        _isMoving = true; // Empêche le déclenchement multiple
        float _elapsedTime = 0f;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = initialPosition + (transform.TransformDirection(Vector3.up) * _DeplacementRange);

        while (_elapsedTime < _timeButton)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, _elapsedTime / _timeButton);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        _isMoving = false;
        StartCoroutine(MovementBack());
    }

    IEnumerator MovementBack()
    {
        _isMovingBack = true;
        float _elapsedTime = 0f;
        Vector3 initialPosition = transform.position;
        Vector3 targetPosition = _saveposition;

        while (_elapsedTime < _timeButton)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, _elapsedTime / _timeButton);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        _isMovingBack = false;
    }

    public void RestCode()
    {
        if (Reset == true)
        {
            _text3d.GetComponent<TextMeshPro>().text = "";
            _text3d.GetComponent<TextMeshPro>().color = Color.white;
        }
        else if (_text3d.GetComponent<TextMeshPro>().text.Length == 4)
        {
            return;
        }
        else if (Validation)
        {
            return;
        }
        else
        {
            _text3d.GetComponent<TextMeshPro>().text += Number;
        }
    }

    public void ValidationCode()
    {
        if(_text3d.GetComponent<TextMeshPro>().text == "1122")
        {
            _text3d.GetComponent<TextMeshPro>().color = Color.green;
        }
        else
        {
            _text3d.GetComponent<TextMeshPro>().color = Color.red;
        }

    }




}