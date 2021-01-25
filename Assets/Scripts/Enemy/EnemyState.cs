using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private enum EnemyStateMachine { patrol, shooting, kamikadze, flyout};
    private EnemyStateMachine _enemyState;
    private EnemyShooting _shooting;
    private EnemyMovement _patrol;
    private EnemyKamikadze _kamikadze;
    private EnemyFlyOut _flyOut;
    public int ListIndex;
    

    // Start is called before the first frame update
    void Start()
    {
        _shooting = GetComponent<EnemyShooting>();
        _patrol = GetComponent<EnemyMovement>();
        _kamikadze = GetComponent<EnemyKamikadze>();
        _flyOut = GetComponent<EnemyFlyOut>();
    }

    // Update is called once per frame
    void Update()
    {
        /*switch (_enemyState)
        {
            case EnemyStateMachine.patrol:
                _shooting.gameObject.SetActive(false);
                _patrol.gameObject.SetActive(true);
                _kamikadze.gameObject.SetActive(false);
                _flyOut.gameObject.SetActive(false);
                break;

            case EnemyStateMachine.shooting:
                _shooting.gameObject.SetActive(true);
                _patrol.gameObject.SetActive(true);
                _kamikadze.gameObject.SetActive(false);
                _flyOut.gameObject.SetActive(false);
                break;

            case EnemyStateMachine.kamikadze:
                _shooting.gameObject.SetActive(false);
                _patrol.gameObject.SetActive(false);
                _kamikadze.gameObject.SetActive(true);
                _flyOut.gameObject.SetActive(false);
                break;

            case EnemyStateMachine.flyout:
                _shooting.gameObject.SetActive(false);
                _patrol.gameObject.SetActive(false);
                _kamikadze.gameObject.SetActive(false);
                _flyOut.gameObject.SetActive(true);
                break;

        
        }*/
    }
}
