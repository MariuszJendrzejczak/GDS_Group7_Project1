using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMe : MonoBehaviour
{
    public Vector2 myPosition;

    void Start()
    {
        myPosition = transform.position;
    }

    public void RespawnToStartPos()
    {
        transform.position = myPosition;
    }
}
