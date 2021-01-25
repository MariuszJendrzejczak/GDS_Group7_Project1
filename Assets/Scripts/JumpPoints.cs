using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoints : MonoBehaviour
{
    [SerializeField]
    private int _value;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UIManager.Instance.UpdatePlayerScore(_value);
        }
    }
}
