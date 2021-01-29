using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyOut : MonoBehaviour
{
    [SerializeField]
    private Vector2 _target;
    [SerializeField] [Tooltip("Prękość poruszania się przeciwnika w jednostkach unity na frame. Dlatego wartość jest tak niska. Zalecam Operować między wartościami 0.01 do 0.06")] 
    private float _step = 0.04f;

    public void FlyOut()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _step);
        if ((Vector2)transform.position == _target)
        {
            gameObject.SetActive(false);
        }
    }
}
