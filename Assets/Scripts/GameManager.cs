using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    [SerializeField]
    private float _ground, _paralax1, _paralax2, _groundY, _paralax1Y, _paralax2Y;
    [SerializeField]
    private GameObject _groundObj, _paralax1Obj, _paralax2Obj;
    public GameObject PlayerCar;
    [SerializeField]
    private GameObject _pausePanel, _bounsPanel, _respawnPanel, _gameOverPanel, _finalPanel;
    private enum GameState { play, paused }
    private GameState gameState = GameState.play;
    private int _playerLives = 4, _sceneIndex;
    [SerializeField]
    private bool _unlimitedLives = false;
    public float Timer { get; set; }
    [SerializeField]
    private AudioSource _music;

    
    private void Awake()
    {
        _instance = this;
        Time.timeScale = 1;
 
 
    }

    private void Start()
    {

    }
    private void Update()
    {
        UpdateEnviroment();
        Pause();
        GameTimer();

        _sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.O))
            _music.volume += 0.1f;
        if (Input.GetKeyDown(KeyCode.I))
            _music.volume -= 0.1f;
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (_music.mute == true)
                _music.mute = false;
            else if (_music.mute == false)
                _music.mute = true;
        }
            
        

    }

    private void UpdateEnviroment()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            if (_groundObj == null)
                _groundObj = GameObject.Find("Enviroment").transform.GetChild(0).gameObject;
            if (_paralax1Obj == null)
                _paralax1Obj = GameObject.Find("Enviroment").transform.GetChild(1).gameObject;
            if (_paralax2Obj == null)
                _paralax2Obj = GameObject.Find("Enviroment").transform.GetChild(2).gameObject;
        }


    }

    private void GameTimer()
    {
        Timer += Time.deltaTime;
        int inttimer = (int)Timer;
        UIManager.Instance.UpdateTimer(inttimer);
    }

    public void CheckPointUpdate(float ground, float paralax1,float paralax2, float groundY, float paralax1Y, float paralax2Y )
    {
        _ground = ground; _groundY = groundY;
        _paralax1 = paralax1; _paralax1Y = paralax1;
        _paralax2 = paralax2; _paralax2Y = paralax2;
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
        if (_unlimitedLives == true)
            _playerLives = 4;
        UIManager.Instance.UpdatePlayerLives(_playerLives);
        if (_playerLives > 0)
        {
            Time.timeScale = 0;
            Respawn();
        }
        else
        {
            GameOver();
        }

    }
    public void GameOver()
    {
        if (_playerLives == 0)
        {
            Time.timeScale = 0;
            _gameOverPanel.SetActive(true);
            AudioManager.Instanse.AudioGameOver();
        }
    }
    public void BackToMainManu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ContinueGame()
    {
        _playerLives = 4;
        UIManager.Instance.UpdatePlayerLives(_playerLives);
        _gameOverPanel.SetActive(false);
        UIManager.Instance.PlayerScore = 0;
        UIManager.Instance.UpdatePlayerScore(0); 
        Respawn();
        
    }
    public void RespawnPanel()
    {
        Time.timeScale = 0;
        _respawnPanel.SetActive(true);
    }
    public void Respawn()
    {
        SpawnManager.Instance.DestroyEnemyOnPlayerDeath();
        ProgressBar.Instance.AfterRespawnSliderUpdate();
        PlayerDestroy.Instance.Respawn();
        _groundObj.transform.SetPositionAndRotation(new Vector2(_ground, _groundY), Quaternion.identity);
        _paralax1Obj.transform.SetPositionAndRotation(new Vector2(_paralax1, _paralax1Obj.transform.position.y), Quaternion.identity);
        _paralax2Obj.transform.SetPositionAndRotation(new Vector2(_paralax2, _paralax2Obj.transform.position.y), Quaternion.identity);
        SpawnManager.Instance.RespawnDestroyedObjects();
        SpawnManager.Instance.ClearDestroyedObjectList();
        SetActiceFalseForAllChildren.Instance.SetAllChildrenActiveFalse();
        Time.timeScale = 1;

           
    }
    public void BounsPanel()
    {
        
        _bounsPanel.SetActive(true);
        _bounsPanel.GetComponent<Bonus>().BonusCalculation(_sceneIndex);
        var bonus = _bounsPanel.GetComponent<Bonus>();
        UIManager.Instance.BonusPanelUpdate((int)Timer, bonus.currnetTime, bonus.currentTop, bonus.currentBonus);
        Time.timeScale = 0;
    }
    public void BounsPanelFinal()
    {
        _finalPanel.SetActive(true);
        UIManager.Instance.FinalPanelUpdate();

    }

    public void NextLevel()
    {
        _bounsPanel.SetActive(false);
        Time.timeScale = 1;
        Timer = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AddLive()
    {
        _playerLives += 1;
        UIManager.Instance.UpdatePlayerLives(_playerLives);
    }

    public void OdNowa()
    {
        UIManager.Instance.PlayerScore = 0;
        _playerLives = 4;
        SceneManager.LoadScene(1);
    }


 
}
