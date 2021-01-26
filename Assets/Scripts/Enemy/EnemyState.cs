using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public enum EnemyStateMachine { patrol, shooting, kamikadze, flyout};
    public EnemyStateMachine enemyState = EnemyStateMachine.patrol;
    [SerializeField]
    private EnemyShooting _shooting;
    [SerializeField]
    private EnemyMovement _patrol;
    [SerializeField]
    private EnemyKamikadze _kamikadze;
    [SerializeField]
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
        switch (enemyState)
        {
            case EnemyStateMachine.patrol:
                _patrol.Movement();
                break;
            case EnemyStateMachine.shooting:
                _shooting.Shooting();
                _patrol.Movement();
                break;
            case EnemyStateMachine.kamikadze:
                _kamikadze.Kamikadze();
                break;
            case EnemyStateMachine.flyout:
                _flyOut.FlyOut();
                break;

        
        }
    }
}
