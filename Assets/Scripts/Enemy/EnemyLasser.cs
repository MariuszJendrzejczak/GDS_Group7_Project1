using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLasser : MonoBehaviour
{
    public enum LasserType { rocket, holeMaker }
    [SerializeField]
    private LasserType _type;
    [SerializeField]
    private GameObject _hole;
    [SerializeField]
    private float _x, _y;
    [SerializeField]
    private GameObject _enviroment;


    private Rigidbody2D _rigidbody;
    [SerializeField]
    void Start()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(Vector2.left, ForceMode2D.Impulse);
        _enviroment = GameObject.Find("Enviroment");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerDestroy.Instance.DestroyPlayer();
            Destroy(this.gameObject);
        }
        if (collision.tag == "Ground")
        {
            if(_type == LasserType.rocket)
            {
                Destroy(this.gameObject);
            }
            if(_type == LasserType.holeMaker)
            {
                Instantiate(_hole, (Vector2)transform.position + new Vector2(_x, _y), Quaternion.identity).transform.SetParent(_enviroment.transform.GetChild(0));
                Destroy(this.gameObject);
            }

            
        }
    }


}
