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
    private GameObject _pausePanel, _bounsPanel, _respawnPanel, _gameOverPanel;
    private enum GameState { play, paused, playerDead, bounsPanel, gameOver}
    private GameState gameState = GameState.play;
    private bool _paused = false, _playerDead = false;
    private int _playerLives = 3;

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

        //Instantiate(PlayerCar, respawnPoint.position, Quaternion.identity);
        PlayerDestroy.Instance.Respawn();
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
