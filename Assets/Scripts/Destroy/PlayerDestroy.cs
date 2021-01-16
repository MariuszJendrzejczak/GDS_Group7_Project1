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

    private void Awake()
    {
        _instance = this;
    }

    public void DestroyPlayer()
    {
        GameManager.Instance.PlayerDestroyerd();
        gameObject.SetActive(false);
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
    }




}
