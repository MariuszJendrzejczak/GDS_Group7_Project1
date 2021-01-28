using System.Collections;
using System.Collections.Generic;
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



    private void Awake()
    {
        _instance = this;
        _carExplosion = transform.GetChild(0).transform.GetChild(0).gameObject;
        _carExplosion.SetActive(false);
    }

    public void DestroyPlayer()
    {
        AudioManager.Instanse.AudioCarDestroy();
        var explosion = transform.GetChild(0).transform.GetChild(0).gameObject;
        explosion.SetActive(true);
        explosion.transform.SetParent(GameObject.Find("Enviroment").transform.GetChild(0));
        explosion.GetComponent<CarExplosion>().CarExplodionAnim();
        gameObject.SetActive(false); 

    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < transform.childCount; i++)
        {
           transform.GetChild(i).GetComponent<RespawnMe>().RespawnToStartPos();
        }
        _carExplosion.transform.SetParent(transform.GetChild(0));
        _carExplosion.transform.position = transform.GetChild(0).transform.position;
        _carExplosion.SetActive(false);

    }




}
