using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject toSpawn1, toSpawn2, toSpawn3, toSpawn4, toSpawn5, toSpawn6;
    [SerializeField]
    private bool _SeparatorVeribleDoNotTouchIt;


    private BoxCollider2D _collider;
    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        if (_collider == null)
        {
            Debug.Log("Collider is null");
        }
        if (_SeparatorVeribleDoNotTouchIt == true)
            Debug.Log("DO NOT TOUCH!!! Co w tych słowach jest niezrozumiałe?");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (toSpawn1 != null)
            {
                SpawnManager.Instance.AddToSpawn(toSpawn1);
            }
                
            if (toSpawn2 != null)
            {
                SpawnManager.Instance.AddToSpawn(toSpawn2);
            }
                
            if (toSpawn3 != null)
                SpawnManager.Instance.AddToSpawn(toSpawn3);
            if (toSpawn4 != null)
                SpawnManager.Instance.AddToSpawn(toSpawn4);
            if (toSpawn5 != null)
                SpawnManager.Instance.AddToSpawn(toSpawn5);
            if (toSpawn6 != null)
                SpawnManager.Instance.AddToSpawn(toSpawn6);

            SpawnManager.Instance.StartSpawn();
            _collider.enabled = false;
            SpawnManager.Instance.ClearLists();
            


        }
    }
}
