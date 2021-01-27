﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalseForChilds : MonoBehaviour
{

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void SetActiveFalseToAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    
}
