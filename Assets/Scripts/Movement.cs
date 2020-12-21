using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 3;
    [SerializeField]
    private float _jumpForce = 5;

    [SerializeField]
    private enum Type { carBody, carWheel, GroudLayer, FrontGraund, BackGround}

    private float _move;

    private Rigidbody2D _rigidbody2D;

    Vector2 rightVector;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        MovementMethod();
    }

    void MovementMethod()
    {
        _move = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_move * _playerSpeed, _rigidbody2D.velocity.y);
        //Vector2 movement = new Vector2(_move * _playerSpeed, transform.position.y);
        //transform.Translate(movement * Time.deltaTime);
    }
    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }
    }
}
