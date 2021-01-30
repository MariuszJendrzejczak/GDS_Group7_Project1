using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerCar;
    [SerializeField]
    private bool _freeze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerCar == null)
        {
            _playerCar = GameObject.Find("PlayerCarVer.03(Clone)").gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (_freeze)
            {
                _playerCar.transform.GetChild(0).GetComponent<Rigidbody2D>().freezeRotation = true;
                _playerCar.transform.GetChild(1).GetComponent<Rigidbody2D>().freezeRotation = true;
                _playerCar.transform.GetChild(2).GetComponent<Rigidbody2D>().freezeRotation = true;
                _playerCar.transform.GetChild(3).GetComponent<Rigidbody2D>().freezeRotation = true;
            }
            else
            {
                _playerCar.transform.GetChild(0).GetComponent<Rigidbody2D>().freezeRotation = false;
                _playerCar.transform.GetChild(1).GetComponent<Rigidbody2D>().freezeRotation = false;
                _playerCar.transform.GetChild(2).GetComponent<Rigidbody2D>().freezeRotation = false;
                _playerCar.transform.GetChild(3).GetComponent<Rigidbody2D>().freezeRotation = false;
            }
            
        }
    }
}
