using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMovement : MonoBehaviour
{
    [SerializeField][Tooltip("Szybkość poruszania się tego objektu (Default: Podłoga 5, Budynki 3, Góry 1")] private float _speed = 5f;
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
