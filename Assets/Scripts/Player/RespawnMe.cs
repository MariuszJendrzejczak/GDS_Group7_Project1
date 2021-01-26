using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMe : MonoBehaviour
{
    public Vector2 myPosition;

    void Start()
    {
        myPosition = new Vector2(-0.547f, 0.099f);
    }

    public void RespawnToStartPos()
    {
     //   transform.position = myPosition;
    }
}
