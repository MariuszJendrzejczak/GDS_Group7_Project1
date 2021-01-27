using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private Text _scoreText, _topScoreText, _lives, _timer;
    [SerializeField]
    private Text _yourTime, _avgTime, _topTime, _bounsPoints, _pointLetter;
    private int _topScore = 0;
    public int PlayerScore;
    private bool _bunusLife1 = false, _bonusLife2 = false;

    



    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTopScore(PlayerScore);
        
    }

   

    public void UpdatePlayerScore(int value)
    {
        PlayerScore += value;
        if (PlayerScore == 0)
            _scoreText.text = "00000";
        if (PlayerScore >= 100 && value < 1000)
            _scoreText.text = "00" + PlayerScore;
        if (PlayerScore >= 1000 && value < 10000)
            _scoreText.text = "0" + PlayerScore;
        if (PlayerScore >= 10000)
        {
            _scoreText.text = "" + PlayerScore;
            if (_bunusLife1 == false)
            {
                GameManager.Instance.AddLive();
                _bunusLife1 = true;
            }         
            if (_bonusLife2 == false && PlayerScore >=30000)
            {
                GameManager.Instance.AddLive();
                _bonusLife2 = false;
            }
                

        }



    }

    private void UpdateTopScore(int value)
    {
        if (value > _topScore)
        {
            _topScore = PlayerScore;

            if (value == 0)
                _topScoreText.text = "00000";
            if (value >= 100 && value < 1000)
                _topScoreText.text = "00" + _topScore;
            if (value >= 1000 && value < 10000)
                _topScoreText.text = "0" + _topScore;
            if (value >= 10000)
                _topScoreText.text = "" + _topScore;
        }
    }

    public void UpdatePlayerLives(int value)
    {
        _lives.text = "" + value;
    }

    public void UpdateTimer(int value)
    {
        if (value < 10)
            _timer.text = "00" + value;
        if (value < 100 && value >= 10)
            _timer.text = "0" + value;
        if (value >= 100)
            _timer.text = "" + value;
    }
    public void BonusPanelUpdate(int yourTime, int avgTime, int topTime, int bonusPoints)
    {
        _yourTime.text = yourTime.ToString();
        _avgTime.text = avgTime.ToString();
        _topTime.text = topTime.ToString();
        _bounsPoints.text = bonusPoints.ToString();
    }

    public void UpdateCheckPointLetter(string value)
    {
        _pointLetter.text = value;
    }

    
    
}
