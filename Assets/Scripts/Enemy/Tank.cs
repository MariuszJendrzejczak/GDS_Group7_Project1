using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public bool active = false, shoot = true;
    [SerializeField]
    private GameObject _projectile;
    private Vector2 _vector;
    [SerializeField]
    float _x, _y;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _vector = new Vector2(transform.position.x + _x, transform.position.y + _y);
        if (active && shoot)
        {
            Instantiate(_projectile, _vector, Quaternion.identity);
            shoot = false;
            
        }
    }
}
