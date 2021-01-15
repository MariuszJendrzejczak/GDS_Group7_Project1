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

    public List<GameObject> ObjectsToSpawn;
    [SerializeField]
    private List<Transform> _transformsForSpawn;
    private int _childCount;

    private void Awake()
    {
        _instance = this;

        _childCount = transform.childCount;
        for (int i = 0; i < _childCount; i++)
        {
            _transformsForSpawn.Add(transform.GetChild(i));
        }
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AddToSpawn(GameObject obj)
    {
        ObjectsToSpawn.Add(obj);
    }

    public void StartSpawn()
    {
        for (int i = 0; i < ObjectsToSpawn.Count; i++)
        {
            Instantiate(ObjectsToSpawn[i], _transformsForSpawn[i]);
            
        }
        
    }

    public void ClearLists()
    {
        ObjectsToSpawn.Clear();
    }

}
