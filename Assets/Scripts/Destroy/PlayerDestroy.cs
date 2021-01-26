using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    private static PlayerDestroy _instance;
    public static PlayerDestroy Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private GameObject _carExplosion;
    [SerializeField]
    private Transform _bodyTransform;

    private void Awake()
    {
        _instance = this;
    }

    public void DestroyPlayer()
    {
         AudioManager.Instanse.AudioCarDestroy();
         //Instantiate(_carExplosion, _bodyTransform.position, Quaternion.identity).transform.SetParent(GameObject.Find("Enviroment").transform.GetChild(0).transform);
        GameManager.Instance.PlayerDestroyerd();
        gameObject.SetActive(false); 

    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < transform.childCount; i++)
        {
           transform.GetChild(i).GetComponent<RespawnMe>().RespawnToStartPos();
        }
        
    }




}
