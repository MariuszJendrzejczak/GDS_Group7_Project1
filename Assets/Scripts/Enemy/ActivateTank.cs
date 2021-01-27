using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActivateTank : MonoBehaviour
{
    [SerializeField]
    private RoundRock _tank;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _tank.active = true;
        }
    }
}




