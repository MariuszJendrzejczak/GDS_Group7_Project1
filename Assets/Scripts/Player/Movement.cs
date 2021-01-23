﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] [Tooltip("Wartość określająca szybkość poruszania się pojazdu (default: 3)")] private float _playerSpeed = 3;
    [SerializeField] [Tooltip("Wartość określająca siłę skoku pojazdu (default: 5)")]private float _jumpForce = 5;
    private float _move;
    private Rigidbody2D _rigidbody2D;
    private bool _jumping = false;
    private float _jumpingTime = 0.9f;

    Vector2 rightVector;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _jumping = false;
    }

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
