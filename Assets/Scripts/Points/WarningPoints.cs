using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPoints : MonoBehaviour
{
    private enum Type { high, medium, low}
    [SerializeField]
    private Type _type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (_type)
            {
                case Type.high:
                    break;
                case Type.medium:
                    break;
                case Type.low:
                    break;
            }

        }
    }
}
