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
    public List<Transform> TransformsForSpawn;

    private void Awake()
    {
        _instance = this;
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void AddToSpawn(GameObject obj, Transform transform)
    {
        ObjectsToSpawn.Add(obj);
        TransformsForSpawn.Add(transform);
    }

    public void StartSpawn()
    {
        for (int i = 0; i < ObjectsToSpawn.Count; i++)
        {
            Instantiate(ObjectsToSpawn[i], TransformsForSpawn[i]);
            
        }
        
    }

    public void ClearLists()
    {
        ObjectsToSpawn.Clear();
        TransformsForSpawn.Clear();
    }

}
