using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoundRock : MonoBehaviour
{
    [SerializeField]
    private RoundRock _rock;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _rock.active = true;
        }
    }


}
