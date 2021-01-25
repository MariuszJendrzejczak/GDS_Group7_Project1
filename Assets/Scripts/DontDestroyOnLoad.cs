using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
        if (SceneManager.GetActiveScene().buildIndex == 0)
            Destroy(this.gameObject);
    }

}
