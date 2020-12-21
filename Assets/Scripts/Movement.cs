using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 3;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private enum Type { carBody, carWheel, GroudLayer, FrontGraund, BackGround}
    [SerializeField] private Type _type;
    private float _move;
    private Rigidbody2D _rigidbody2D;
    private bool _jumping = false;
    private float _jumpingTime = 1f;

    Vector2 rightVector;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        Jump();
        MovementMethod();
    }

    void MovementMethod()
    {
        _move = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_move * _playerSpeed, _rigidbody2D.velocity.y);

    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _jumping == false)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _jumping = true;
            StartCoroutine(Jumping());

        }
    }

    IEnumerator Jumping()
    {
        yield return new WaitForSeconds(_jumpingTime);
        _jumping = false;
    }

}
