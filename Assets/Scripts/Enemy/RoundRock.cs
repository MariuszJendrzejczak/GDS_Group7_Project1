using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundRock : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public bool active = false;
    [SerializeField]
    private Vector2 _move;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (transform.parent.name != "RockContainer")
            {
                transform.SetParent(GameObject.Find("RockContainer").transform);
            }
            Debug.Log("jestem");
            _rigidbody2D.velocity = _move;
        }

    }
}
