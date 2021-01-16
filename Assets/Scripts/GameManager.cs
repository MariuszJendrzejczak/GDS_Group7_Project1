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

    private float _ground, _paralax1, _paralax2;
    [SerializeField]
    private GameObject _groundObj, _paralax1Obj, _paralax2Obj;
    public GameObject PlayerCar;
    [SerializeField]
    private GameObject _pausePanel, _bounsPanel, _respawnPanel, _gameOverPanel;
    private enum GameState { play, paused, playerDead, bounsPanel, gameOver}
    private GameState gameState = GameState.play;
    private int _playerLives = 3;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
     //   _groundObj = GameObject.Find("GroundLayer").GetComponent<GameObject>();
     //   _paralax1Obj = GameObject.Find("ParalaxLayer1").GetComponent<GameObject>();
     //   _paralax2Obj = GameObject.Find("ParalaxLayer2").GetComponent<GameObject>();
    }
    private void Update()
    {
        Pause();


    }

    public void CheckPointUpdate(float ground, float paralax1,float paralax2 )
    {
        _ground = ground;
        _paralax1 = paralax1;
        _paralax2 = paralax2;
    }
  

    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P)&& gameState == GameState.play)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            gameState = GameState.paused;
        }
        else if(Input.GetKeyDown(KeyCode.P) && gameState == GameState.paused)
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
            gameState = GameState.play;
        }

    }

    public void PlayerDestroyerd()
    {
        _playerLives--;
        if (_playerLives > 0)
        {
            gameState = GameState.playerDead;
            RespawnPanel();
        }
        else
        {
            gameState = GameState.gameOver;
            GameOver();
        }

    }
    public void GameOver()
    {
        if (_playerLives == 0)
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
        }
    }
    public void BackToMainManu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ContinueGame()
    {
        _playerLives = 3;
        //score = 0;
        _gameOverPanel.SetActive(false);
        Respawn();
        
    }
    public void RespawnPanel()
    {
        Time.timeScale = 0;
        _respawnPanel.SetActive(true);
    }
    public void Respawn()
    {

        PlayerDestroy.Instance.Respawn();
        _groundObj.transform.SetPositionAndRotation(new Vector2(_ground, _groundObj.transform.position.y), Quaternion.identity);
        _paralax1Obj.transform.SetPositionAndRotation(new Vector2(_paralax1, _paralax1Obj.transform.position.y), Quaternion.identity);
        _paralax2Obj.transform.SetPositionAndRotation(new Vector2(_paralax2, _paralax2Obj.transform.position.y), Quaternion.identity);
            Time.timeScale = 1;
        _respawnPanel.SetActive(false);
           
    }
    public void BounsPanel()
    {
        Time.timeScale = 0;
        _bounsPanel.SetActive(true);
        gameState = GameState.bounsPanel;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
