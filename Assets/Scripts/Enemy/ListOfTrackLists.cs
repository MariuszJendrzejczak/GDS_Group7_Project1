using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfTrackLists : MonoBehaviour
{
    private static ListOfTrackLists _instance;
    public static ListOfTrackLists Instance
    {
        get { return _instance; }
    }
    public List<List<Transform>> TrackLists; 
    int childCount;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        TrackLists = new List<List<Transform>>();
        childCount = this.transform.childCount;


        for (int i = 0; i < childCount; i++)
        {
            var obj = gameObject.transform.GetChild(i).GetComponent<TrackList>();
            TrackLists.Add(obj.transformList);

        }
    }

    public List<List<Transform>> InportLists()
    {
        return TrackLists;
    }

}
