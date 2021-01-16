using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }

    public Transform respawnPoint;
    public GameObject PlayerCar;

    private void Awake()
    {
        _instance = this;
    }

    public void CheckPointUpdate(Transform point)
    {
        respawnPoint = point;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(PlayerCar, respawnPoint);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
