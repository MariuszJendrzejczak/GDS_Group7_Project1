using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool _isFinal = false;

    private Transform _groundLayer, _paralax1Layer, _paralax2Layer;
    private float _ground, _paralax1, _paralax2;
    [SerializeField]
    private Transform _groundObj, _paralax1Obj, _paralax2Obj;

    private void Start()
    {
        _groundObj = GameObject.Find("GroundLayer").GetComponent<Transform>();
        _paralax1Obj = GameObject.Find("ParalaxLayer1").GetComponent<Transform>();
        _paralax2Obj = GameObject.Find("ParalaxLayer2").GetComponent<Transform>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (_isFinal == true)
        {
            GameManager.Instance.BounsPanel();
        }
        
            
        if (collision.tag == "Player")
        {
            _ground = _groundObj.transform.position.x;
            _paralax1 = _paralax1Obj.transform.position.x;
            _paralax2 = _paralax2Obj.transform.position.x;
            GameManager.Instance.CheckPointUpdate(_ground, _paralax1, _paralax2);
            SpawnManager.Instance.ClearDestroyedObjectList();
        }
        
    }
}
