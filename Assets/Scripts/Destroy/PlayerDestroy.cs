using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    private static PlayerDestroy _instance;
    public static PlayerDestroy Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }



    /*/ private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rock")
        {
            Destroy(transform.parent.gameObject);
        }
            
        if (collision.tag == "EnemyLasser")
        {
            Destroy(transform.parent.gameObject);
        }

        if (collision.tag == "Hole")
        {
            Destroy(transform.parent.gameObject);
        }
    }*/
}
