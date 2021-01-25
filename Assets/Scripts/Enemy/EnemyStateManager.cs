using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [SerializeField]
    private EnemyState _enemy0, _enemy1, _enemy2, _enemy3, _enemy4, _enemy5;
    [SerializeField]
    //private List<EnemyState> _enemyList;
    //private int _childCount;
    // Start is called before the first frame update
    /*private void Awake()
    {
        _childCount = this.transform.childCount;
        for (int i = 0; i < _childCount; i++)
        {
            _enemyList.Add(transform.GetChild(i).GetComponent<EnemyState>());
        }
    }*/

    void Start()
    {
       // _enemyList.Add(_enemy0); _enemyList.Add(_enemy1); _enemyList.Add(_enemy2); _enemyList.Add(_enemy3); _enemyList.Add(_enemy4); _enemyList.Add(_enemy5);

    }

    // Update is called once per frame
    void Update()
    {
        GetComponentsToVaribles();
    }

    private void GetComponentsToVaribles()
    {
        for (int i = 0; i < transform.GetChildCount(); i++)
        {

        }

        
        if (transform.GetChildCount() > 0)
        _enemy0 = transform.GetChild(0).GetComponent<EnemyState>();
        if (transform.GetChildCount() > 1)
        _enemy1 = transform.GetChild(1).GetComponent<EnemyState>();
        if (transform.GetChildCount() > 2)
        _enemy2 = transform.GetChild(2).GetComponent<EnemyState>();
        if (transform.GetChildCount() > 3) 
        _enemy3 = transform.GetChild(3).GetComponent<EnemyState>();
        if (transform.GetChildCount() > 4)
        _enemy4 = transform.GetChild(4).GetComponent<EnemyState>();
        if (transform.GetChildCount() > 5)
        _enemy5 = transform.GetChild(5).GetComponent<EnemyState>();
        
    }
}
