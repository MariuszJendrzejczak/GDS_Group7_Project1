using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSceneRespawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerCar;

    private void Start()
    {
        Instantiate(_playerCar, new Vector2(-0.547f, 0.099f), Quaternion.identity);
        Debug.Log("Jestem");
    }
}
