using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKamikadze : MonoBehaviour
{
    [SerializeField]
    private Transform _target, _transformLocked;
    [SerializeField]
    [Tooltip("Prękość poruszania się przeciwnika w jednostkach unity na frame. Dlatego wartość jest tak niska. Zalecam Operować między wartościami 0.01 do 0.06")]
    private float _step = 0.04f;
    private bool _targetLocked = false;

    private void Start()
    {
            _target= GameObject.Find("PlayerCarVer.03(Clone)").transform.GetChild(0).transform;
    }
    public void Kamikadze()
    {
        if (_targetLocked == false)
        {
            _transformLocked = _target;
            _targetLocked = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, _transformLocked.position, _step);
       
        if (transform == _transformLocked)
        {
            Destroy(this.gameObject);
        }
    }
}
