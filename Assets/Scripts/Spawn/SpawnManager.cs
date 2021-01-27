using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance;
    public static SpawnManager Instance
    {
        get { return _instance; }
    }

    public List<GameObject> EnemyesToSpawn, SpawnedEnemy;
    [SerializeField]
    private List<Transform> _transformsForSpawn;
    private int _childCount;

    private List<GameObject> _destroyerdObjects = new List<GameObject>();

    [SerializeField]
    private GameObject _enemyContainer;
    [SerializeField]
    private SetActiveFalseForChilds _ufo1, _ufo2, _ufo3;

    private void Awake()
    {
        _instance = this;
        AwakeTransformList();
    }

    private void Start()
    {
        _ufo1 = transform.GetChild(6).transform.GetChild(0).GetComponent<SetActiveFalseForChilds>();
        _ufo2 = transform.GetChild(6).transform.GetChild(1).GetComponent<SetActiveFalseForChilds>();
        _ufo3 = transform.GetChild(6).transform.GetChild(2).GetComponent<SetActiveFalseForChilds>();
    }


    public void AwakeTransformList()
    {
        _childCount = transform.childCount;
        for (int i = 0; i < _childCount - 1; i++)
        {
            _transformsForSpawn.Add(transform.GetChild(i));
        }
    }

    public void AddToSpawn(GameObject obj)
    {
        EnemyesToSpawn.Add(obj);
    }

    public void StartSpawn()
    {
        for (int i = 0; i < EnemyesToSpawn.Count; i++)
        {
            /*Instantiate(EnemyesToSpawn[i], _transformsForSpawn[i].position, Quaternion.identity).transform.SetParent(_enemyContainer.transform);

             SpawnedEnemy.Add(EnemyesToSpawn[i]);*/

            EnemyesToSpawn[i].transform.position = _transformsForSpawn[i].position;
            EnemyesToSpawn[i].SetActive(true);
            
        }
        
    }

    public void ClearLists()
    {
        EnemyesToSpawn.Clear();
    }

    public void AddDestroyerObjToList(GameObject obj)
    {
        _destroyerdObjects.Add(obj);
    }

    public void RespawnDestroyedObjects()
    {
        foreach (GameObject obj in _destroyerdObjects)
        {
            obj.SetActive(true);
        }
    }
    public void ClearDestroyedObjectList()
    {
        _destroyerdObjects.Clear();
    }

    public void DestroyEnemyOnPlayerDeath()
    {
        _ufo1.SetActiveFalseToAll();
        _ufo2.SetActiveFalseToAll();
        _ufo3.SetActiveFalseToAll();
    }
}
