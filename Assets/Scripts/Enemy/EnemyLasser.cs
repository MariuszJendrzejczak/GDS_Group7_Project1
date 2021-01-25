using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLasser : MonoBehaviour
{
    public enum LasserType { first, second }
    [SerializeField]
    private LasserType _type;
    private float _destroyTime;
    [SerializeField]
    [Tooltip("Szybkość poruszania się lasera (Default: 8)")]
    private float _speed = 8.0f;
    private Rigidbody2D _rigidbody;
    [SerializeField]
    //private Transform _carBody;
    // Start is called before the first frame update
    void Start()
    {
        _destroyTime = 1.5f;
        _rigidbody = GetComponent<Rigidbody2D>();
        //if (transform.position.x > _carBody.position.x)
       // {
            _rigidbody.AddForce(Vector2.left, ForceMode2D.Impulse);
       // }
       // if (transform.position.x < _carBody.position.x)
        //{
        //    _rigidbody.AddForce(Vector2.right, ForceMode2D.Impulse);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.down * _speed * Time.deltaTime);
       
    }

    IEnumerator DestroyLasser()
    {


        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);

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
            Destroy(this.gameObject);
        }
    }


}
