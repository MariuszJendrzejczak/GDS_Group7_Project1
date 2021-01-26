using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private static EnemyStateManager _instance;
    public static EnemyStateManager Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private EnemyState _enemy0, _enemy1, _enemy2, _enemy3, _enemy4, _enemy5;
    [SerializeField]
    public enum Mode { Normal, Attack}
    [SerializeField]
    public Mode mode;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
       

    }

  
    void Update()
    {
        GetComponentsToVaribles();
        if (mode == Mode.Normal)
            ShootAndPatrol();
        if (mode == Mode.Attack)
            KamikadzeAndFlyOut();
        
    }

    private void GetComponentsToVaribles()
    {
        if (transform.childCount > 0)
        _enemy0 = transform.GetChild(0).GetComponent<EnemyState>();
        if (transform.childCount > 1)
        _enemy1 = transform.GetChild(1).GetComponent<EnemyState>();
        if (transform.childCount > 2)
        _enemy2 = transform.GetChild(2).GetComponent<EnemyState>();
        if (transform.childCount > 3) 
        _enemy3 = transform.GetChild(3).GetComponent<EnemyState>();
        if (transform.childCount > 4)
        _enemy4 = transform.GetChild(4).GetComponent<EnemyState>();
        if (transform.childCount > 5)
        _enemy5 = transform.GetChild(5).GetComponent<EnemyState>();       
    }

    private void ShootAndPatrol()
    {
        if (_enemy0)
            _enemy0.enemyState = EnemyState.EnemyStateMachine.shooting;
        if (_enemy1)
            _enemy1.enemyState = EnemyState.EnemyStateMachine.patrol;
        if (_enemy2)
            _enemy2.enemyState = EnemyState.EnemyStateMachine.patrol;
        if (_enemy3)
            _enemy3.enemyState = EnemyState.EnemyStateMachine.patrol;
        if (_enemy4)
            _enemy4.enemyState = EnemyState.EnemyStateMachine.patrol;
        if (_enemy5)
            _enemy5.enemyState = EnemyState.EnemyStateMachine.patrol;
    }

    private void KamikadzeAndFlyOut()
    {
        if (_enemy0)
            _enemy0.enemyState = EnemyState.EnemyStateMachine.kamikadze;
        if (_enemy1)
            _enemy1.enemyState = EnemyState.EnemyStateMachine.flyout;
        if (_enemy2)
            _enemy2.enemyState = EnemyState.EnemyStateMachine.flyout;
        if (_enemy3)
            _enemy3.enemyState = EnemyState.EnemyStateMachine.flyout;
        if (_enemy4)
            _enemy4.enemyState = EnemyState.EnemyStateMachine.flyout;
        if (_enemy5)
            _enemy5.enemyState = EnemyState.EnemyStateMachine.flyout;
    }
}
