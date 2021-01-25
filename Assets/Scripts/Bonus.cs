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
    // Start is called before the first frame update


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
                    UIManager.Instance.UpdatePlayerScore((_time1 - (int)GameManager.Instance.Timer) * 100 + 1000);
                    Debug.Log("Byłem tu");
                }
                break;
            case 2:
                if (GameManager.Instance.Timer < _time2)
                {
                    UIManager.Instance.UpdatePlayerScore((_time2 - (int)GameManager.Instance.Timer) * 100 + 1000);
                }
                break;
            case 3:
                if (GameManager.Instance.Timer < _time3)
                {
                    UIManager.Instance.UpdatePlayerScore((_time3 - (int)GameManager.Instance.Timer) * 100 + 1000);
                }
                break;
            case 4:
                if (GameManager.Instance.Timer < _time4)
                {
                    UIManager.Instance.UpdatePlayerScore((_time4 - (int)GameManager.Instance.Timer) * 100 + 1000);
                }
                break;
            case 5:
                if (GameManager.Instance.Timer < _time5)
                {
                    UIManager.Instance.UpdatePlayerScore((_time5 - (int)GameManager.Instance.Timer) * 100 + 5000);
                }
                break;
                
        }
    }
}
