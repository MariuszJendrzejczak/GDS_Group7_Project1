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

    public List<GameObject> EnemyesToSpawn;
    [SerializeField]
    private List<Transform> _transformsForSpawn;
    private int _childCount;

    private List<GameObject> _destroyerdObjects = new List<GameObject>();

    private void Awake()
    {
        _instance = this;
        AwakeTransformList();

        
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log(_destroyerdObjects.Count);
    }

    public void AwakeTransformList()
    {
        _childCount = transform.childCount;
        for (int i = 0; i < _childCount; i++)
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
            Instantiate(EnemyesToSpawn[i], _transformsForSpawn[i]);
            
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
}
