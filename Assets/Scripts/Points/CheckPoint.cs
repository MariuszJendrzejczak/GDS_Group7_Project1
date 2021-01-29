using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private bool _isFinal = false, _ZPoint = false;
    [SerializeField]
    private string _checkPointLetter;

    private Transform _groundLayer, _paralax1Layer, _paralax2Layer;
    private float _ground, _paralax1, _paralax2, _groundY, _paralax1Y, _paralax2Y;
    [SerializeField]
    private Transform _groundObj, _paralax1Obj, _paralax2Obj;
    [SerializeField]


    private void Start()
    {
        _groundObj = GameObject.Find("GroundLayer").GetComponent<Transform>();
        _paralax1Obj = GameObject.Find("ParalaxLayer1").GetComponent<Transform>();
        _paralax2Obj = GameObject.Find("ParalaxLayer2").GetComponent<Transform>();
    }
    private void OnLevelWasLoaded(int level)
    {
        _groundObj = GameObject.Find("GroundLayer").GetComponent<Transform>();
        _paralax1Obj = GameObject.Find("ParalaxLayer1").GetComponent<Transform>();
        _paralax2Obj = GameObject.Find("ParalaxLayer2").GetComponent<Transform>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.Instance.UpdateCheckPointLetter(_checkPointLetter);
        ProgressBar.Instance.ResetCounter();

        if (_isFinal == true)
        {
            GameManager.Instance.BounsPanel();
            AudioManager.Instanse.StopBackgroundMusic();
            AudioManager.Instanse.AudioEndScenePoint();
            ProgressBar.Instance.ActivateProgressBall();
        }

        if (_ZPoint == true)
        {
            GameManager.Instance.BounsPanel();
            GameObject.Find("Canvas").transform.GetChild(3).transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);
            AudioManager.Instanse.StopBackgroundMusic();
            AudioManager.Instanse.AudioZPoint();
            ProgressBar.Instance.ActivateProgressBall();
        }
        
            
        if (collision.tag == "Player")
        {
            _ground = _groundObj.transform.position.x;
            _groundY = _groundObj.transform.position.y;
            _paralax1 = _paralax1Obj.transform.position.x;
            _paralax1Y = _paralax1Obj.transform.position.y;
            if (_paralax2 != null)
            {
                _paralax2 = _paralax2Obj.transform.position.x;
                _paralax2Y = _paralax2Obj.transform.position.y;
            }
                
            GameManager.Instance.CheckPointUpdate(_ground, _paralax1, _paralax2, _groundY, _paralax1Y, _paralax2Y);
            SpawnManager.Instance.ClearDestroyedObjectList();
            AudioManager.Instanse.AudioMiddlePoint();
            
        }
        
    }
}
