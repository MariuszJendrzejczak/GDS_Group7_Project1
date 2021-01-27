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
    [SerializeField][Tooltip("x i y ofset dla spawnowania dziury. Impuls oznacza siłę odrzutu pocisku w prawo/lewo w momencie wystrzału")]
    private float _x, _y, _impulse;
    private GameObject _enviroment;
    private Transform _carBody;

    private Rigidbody2D _rigidbody;
    [SerializeField]
    void Start()
    {
        _enviroment = GameObject.Find("Enviroment");
        _carBody = GameObject.Find("PlayerCarVer.03(Clone)").transform.GetChild(0).transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        if (transform.position.x > _carBody.position.x)
            _rigidbody.AddForce(Vector2.left * _impulse, ForceMode2D.Impulse);
        if (transform.position.x <= _carBody.position.x)
            _rigidbody.AddForce(Vector2.right * _impulse, ForceMode2D.Impulse);
        
        

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
