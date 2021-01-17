using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    private bool _ifShooted = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_ifShooted == true)
        {
            StartCoroutine(Shoot());
            _ifShooted = false;
        }
    }

   IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(4, 10));
        Instantiate(_projectile, transform.position, Quaternion.identity);
        _ifShooted = true;
    }
}

