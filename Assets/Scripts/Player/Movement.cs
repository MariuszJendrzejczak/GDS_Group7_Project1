using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] [Tooltip("Wartość określająca szybkość poruszania się pojazdu (default: 3)")] private float _playerSpeed = 3;
    [SerializeField] [Tooltip("Wartość określająca siłę skoku pojazdu (default: 5)")]private float _jumpForce = 5;
    private float _move;
    [SerializeField]
    private float _thrust = 1;
    private Rigidbody2D _rigidbody2D;
    private bool _jumping = false;
    [SerializeField]
    private float _jumpingTime = 0.95f;
    [SerializeField]
    private Transform _startingPoint;


    Vector2 rightVector;
 
    private void OnEnable()
    {
        _jumping = false;
    }

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_startingPoint == null)
           _startingPoint = GameObject.Find("GameManager").transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {   
        
        Jump();
        if(_jumping == false)
            MovementMethod();
    }

    void MovementMethod()
    {

 
        {
            _move = Input.GetAxis("Horizontal");
            _rigidbody2D.velocity = new Vector2(_move * _playerSpeed, _rigidbody2D.velocity.y);
            if (_move == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, _startingPoint.position, 0.001f);
            }
        }  

    }

 
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumping == false)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _jumping = true;
            AudioManager.Instanse.AudioCarJump();
            StartCoroutine(Jumping());

        }
    }

    IEnumerator Jumping()
    {
        yield return new WaitForSeconds(_jumpingTime);
        _jumping = false;
    }

}
