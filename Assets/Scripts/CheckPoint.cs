using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool _isFinal = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_isFinal == true)
        {
            GameManager.Instance.BounsPanel();
        }
        
            
        if (collision.tag == "Player")
        {
            GameManager.Instance.CheckPointUpdate(transform);
        }
        
    }
}
