using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerDestroy.Instance.DestroyPlayer();
            Destroy(gameObject);
        }
        if (collision.tag == "Lasser")
        {
            Destroy(gameObject);
        }


    }

}
