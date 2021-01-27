using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyStateManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> EnemyList;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            EnemyList.Add(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StateUptadeNormal()
    {
        foreach (GameObject obj in EnemyList)
        {
            if (obj.activeInHierarchy == true)
            {
                obj.GetComponent<EnemyState>().enemyState = EnemyState.EnemyStateMachine.shooting;
                break;
            }
        }
    }

    public void KamikadzeAndFlyOutStateActivation()
    {
        foreach (GameObject obj in EnemyList)
        {
            if(obj.activeInHierarchy == true)
            {
                obj.GetComponent<EnemyState>().enemyState = EnemyState.EnemyStateMachine.flyout;
            }
        }
        foreach (GameObject obj in EnemyList)
        {
            if (obj.activeInHierarchy == true)
            {
                obj.GetComponent<EnemyState>().enemyState = EnemyState.EnemyStateMachine.kamikadze;
                break;
            }
        }
    }
    public void FlyOutStateOnly()
    {
        foreach (GameObject obj in EnemyList)
        {
            if (obj.activeInHierarchy == true)
            {
                obj.GetComponent<EnemyState>().enemyState = EnemyState.EnemyStateMachine.flyout;
            }
        }
    }
}
