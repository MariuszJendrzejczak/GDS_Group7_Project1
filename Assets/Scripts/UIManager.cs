using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private int _topScore = 0;
    public int PlayerScore { get; set; }



    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: ";
        _topScoreText.text = "Top Score: "; // do usunięcia w późniejszym czasie!!!
        _lives.text = "Lives: 4";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTopScore();
    }

    public void UpdatePlayerScore(int value)
    {
        PlayerScore += value;
        _scoreText.text = "Score: " + PlayerScore;
    }

    private void UpdateTopScore()
    {
       if (PlayerScore > _topScore)
        {
            _topScore = PlayerScore;
            _topScoreText.text = "Top Score: " + _topScore;
        }
    }

    public void UpdatePlayerLives(int value)
    {
        _lives.text = "Lives: " + value;
    }

    public void UpdateTimer(int value)
    {
        _timer.text = "Timer: " + value; 
    }
}
