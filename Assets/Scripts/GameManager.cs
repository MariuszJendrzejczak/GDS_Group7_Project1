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
    [SerializeField]
    private GameObject _pausePanel;
    private bool _paused = false;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        Pause();
    }

    public void CheckPointUpdate(Transform point)
    {
        respawnPoint = point;
    }
  

    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P)&& _paused == false)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            _paused = true;
        }
        else if(Input.GetKeyDown(KeyCode.P) && _paused == true)
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
            _paused = false;
        }

    }
}
