using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPoints : MonoBehaviour
{
    private enum Type { high, low}
    [SerializeField]
    private Type _type;
    [SerializeField]
    private GameObject _highWarning, _lowWanrning;

    private void Start()
    {
        _highWarning = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(1).gameObject;
        _lowWanrning = GameObject.Find("Canvas").transform.GetChild(2).transform.GetChild(2).gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            switch (_type)
            {
                case Type.high:
                    _highWarning.SetActive(true);
                    break;

                case Type.low:
                    _lowWanrning.SetActive(true);
                    break;
            }

        }
    }
}
