using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiceFalseForAllChildren : MonoBehaviour
{
    private static SetActiceFalseForAllChildren _instance;
    public static SetActiceFalseForAllChildren Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void SetAllChildrenActiveFalse()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
