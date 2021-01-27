using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField]
    private EnviromentMovement _movement;
    
    private enum Role { Up, Down, Normal}
    [SerializeField]
    private Role _role;
    [SerializeField]
    private Vector2 _vectorUP, _vectorDown;

    void Start()
    {
        _movement = GameObject.Find("Enviroment").transform.GetChild(0).GetComponent<EnviromentMovement>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (_role)
            {
                case Role.Up:
                    _movement.moving = _vectorUP;
                    break;
                case Role.Normal:
                    _movement.moving = Vector2.left;
                    break;
                case Role.Down:
                    _movement.moving = _vectorDown;
                    break;
            }
        }
    }
}
