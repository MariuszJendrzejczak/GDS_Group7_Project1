using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackList : MonoBehaviour
{
    int _childCount;
    public List<Transform> transformList;

    void Awake()
    {

        _childCount = this.transform.childCount;
        for (int i = 0; i < _childCount; i++)
        {
            transformList.Add(transform.GetChild(i));
        }
        
    }


    void Update()
    {
        
    }

    public List<Transform> AddList()
    {
        return transformList;
    }
}
