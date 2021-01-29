using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonus : MonoBehaviour
{
    private int _sceneIndex;
    [SerializeField][Tooltip("Czasy średnie na pokonanie danej sceny. Time1 - Scena A-E... itd.")]
    private int _time1, _time2, _time3, _time4, _time5;
    private int _pointbonus;
    private int top1, top2, top3, top4, top5;
    public int currentTop, currnetTime, currentBonus;
    // Start is called before the first frame update

    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _sceneIndex =  SceneManager.GetActiveScene().buildIndex;
    }

    public void BonusCalculation(int _sceneIndex)
    {
        switch (_sceneIndex)
        {
            case 1:
                if (GameManager.Instance.Timer < _time1)
                {
                    currentBonus = (_time1 - (int)GameManager.Instance.Timer) * 100;
                    currentBonus += 1000;
                    UIManager.Instance.UpdatePlayerScore(currentBonus);
                    if (top1 < GameManager.Instance.Timer)
                    {
                        top1 = (int)GameManager.Instance.Timer;
                    }
                    else
                    {
                        top1 = _time1;
                    }
                    
                }
                currentTop = top1;
                currnetTime = _time1;
                break;
            case 2:
                if (GameManager.Instance.Timer < _time2)
                {
                    currentBonus = (_time2 - (int)GameManager.Instance.Timer) * 100;
                    currentBonus += 1000;
                    UIManager.Instance.UpdatePlayerScore(currentBonus);
                    if (top2 < GameManager.Instance.Timer)
                    {
                        top2 = (int)GameManager.Instance.Timer;
                    }
                    else
                    {
                        top2 = _time2;
                    }
                }
                currentTop = top2;
                currnetTime = _time2;


                break;
            case 3:
                if (GameManager.Instance.Timer < _time3)
                {
                    currentBonus = (_time3 - (int)GameManager.Instance.Timer) * 100;
                    currentBonus += 1000;
                    UIManager.Instance.UpdatePlayerScore(currentBonus);
                    if (top3 < GameManager.Instance.Timer)
                    {
                        top3 = (int)GameManager.Instance.Timer;
                    }
                    else
                    {
                        top3 = _time3;
                    }
                }
                currentTop = top3;
                currnetTime = _time3;

                break;
            case 4:
                if (GameManager.Instance.Timer < _time4)
                {
                    currentBonus = (_time4 - (int)GameManager.Instance.Timer) * 100;
                    currentBonus += 1000;
                    UIManager.Instance.UpdatePlayerScore(currentBonus);
                    if (top4 < GameManager.Instance.Timer)
                    {
                        top4 = (int)GameManager.Instance.Timer;
                    }
                    else
                    {
                        top4 = _time4;
                    }
                }
                currentTop = top4;
                currnetTime = _time4;

                break;
            case 5:
                if (GameManager.Instance.Timer < _time5)
                {
                    currentBonus = (_time5 - (int)GameManager.Instance.Timer) * 100;
                    currentBonus += 5000;
                    UIManager.Instance.UpdatePlayerScore(currentBonus);
                    if (top5 < GameManager.Instance.Timer)
                    {
                        top5 = (int)GameManager.Instance.Timer;
                    }
                    else
                    {
                        top5 = _time5;
                    }
                }
                currentTop = top5;
                currnetTime = _time5;

                break;
                
        }
    }
}
