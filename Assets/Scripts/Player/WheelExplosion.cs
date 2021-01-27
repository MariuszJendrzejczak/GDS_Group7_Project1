using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelExplosion : MonoBehaviour
{
   
    private enum WitchWheel { back, middle, front}
    [SerializeField]
    private WitchWheel _wheel;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    [Tooltip("Pola do ustawiania parametrów Vektorów dla wystrzeliwania kół podczas wybuchu")]
    private float _backX, _backY, _middleX, _middleY, _frontX, _frontY;


    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();



        
    }

    public void ThrowWheels()
    {
        switch (_wheel)
        {
            case WitchWheel.back:
                _rigidbody.AddForce(new Vector2(_backX, _backY), ForceMode2D.Impulse);
                break;
            case WitchWheel.middle:
                _rigidbody.AddForce(new Vector2(_middleX, _middleY), ForceMode2D.Impulse);
                break;
            case WitchWheel.front:
                _rigidbody.AddForce(new Vector2(_frontX, _frontY), ForceMode2D.Impulse);
                break;
        }
    }

    private void OnDisable()
    {
        switch (_wheel)
        {
            case WitchWheel.back:
                transform.position.Set(-0.0662f, -0.205f,0);
                break;
            case WitchWheel.middle:
                transform.position.Set(-0.0499f, -0.232f, 0);
                break;
            case WitchWheel.front:
                transform.position.Set(-0.1046f, -0.233f, 0);
                break;
        }
    }
}
