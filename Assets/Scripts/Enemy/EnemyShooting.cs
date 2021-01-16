using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(1, 10));
        Instantiate(_projectile, transform.position, Quaternion.identity);
        StartCoroutine(Shoot());
    }
}
