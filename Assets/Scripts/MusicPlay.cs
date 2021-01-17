using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad (transform.gameObject);
    }
}
