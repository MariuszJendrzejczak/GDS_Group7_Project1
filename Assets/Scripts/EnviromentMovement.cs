using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{
    [SerializeField] [Tooltip("Szybkość poruszania się tego objektu (Default: Podłoga 0,98, Budynki 0,6, Góry 0,3")]
    private float _minSpeed, _speed = 0.98f, _maxSpeed;
    [SerializeField] [Tooltip("Wartość procentowa zapisana w ułamku dziesiętnym. Skrypt automatycznie przypiszę wartości min i max zmodyfikowane przez tę wartość")]
    private float _adjustmentValue;
    private enum Leyer { Ground, Other}
    [SerializeField]
    private Leyer _leyer;
    [SerializeField]
    public Vector2 moving;
  
    void Start()
    {
        _minSpeed = _speed * (1f - _adjustmentValue);
        _maxSpeed = _speed * (1f + _adjustmentValue);
        moving = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (_leyer == Leyer.Other)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.left * _maxSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector2.left * _minSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * _speed * Time.deltaTime);
            }
        }
       

        if (_leyer == Leyer.Ground)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(moving * _maxSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(moving * _minSpeed * Time.deltaTime);
            }
            else
            {
                transform.Translate(moving * _speed * Time.deltaTime);
            }
        }
        
    }
}
