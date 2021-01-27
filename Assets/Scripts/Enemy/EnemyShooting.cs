using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    private bool _ifShooted = false;
    private EnemyState _state;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void Shooting()
    {
        if (_ifShooted == false)
        {
            StartCoroutine(Shoot());
            _ifShooted = true;
        }
    }

   IEnumerator Shoot()
    {
        yield return new WaitForSeconds(3);
        Instantiate(_projectile, transform.position, Quaternion.identity);
        _ifShooted = false;
    }
}

