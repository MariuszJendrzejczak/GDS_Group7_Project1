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
            SpawnManager.Instance.AddDestroyerObjToList(this.gameObject);
            gameObject.SetActive(false);
            
        }
        if (collision.tag == "Lasser")
        {
            SpawnManager.Instance.AddDestroyerObjToList(this.gameObject);
            gameObject.SetActive(false);
        }


    }

}
