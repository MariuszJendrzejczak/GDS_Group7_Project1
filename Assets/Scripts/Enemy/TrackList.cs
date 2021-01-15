using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackList : MonoBehaviour
{
    int childCount;
    public List<Transform> transformList;

    void Start()
    {

        childCount = this.transform.childCount;
        for (int i = 0; i < childCount; i++)
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
