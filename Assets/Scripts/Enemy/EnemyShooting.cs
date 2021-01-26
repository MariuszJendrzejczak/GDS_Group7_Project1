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
      
    }

    public void Shooting()
    {
        if (_ifShooted == true)
        {
            StartCoroutine(Shoot());
            _ifShooted = false;
        }
    }

   IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);
        Instantiate(_projectile, transform.position, Quaternion.identity);
        _ifShooted = true;
    }
}

