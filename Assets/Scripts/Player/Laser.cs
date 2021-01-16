using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Transactions;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public enum LasserType { horizontal, vertical}
    [SerializeField]
    private LasserType _type;
    private float _destroyTime;

    [SerializeField][Tooltip("Szybkość poruszania się lasera (Default: 8)")]
    private float _speed = 8.0f;


    // Update is called once per frame
    private void Start()
    {
        switch (_type)
        {
            case LasserType.horizontal:
                _destroyTime = 0.5f;
                break;

            case LasserType.vertical:
                _destroyTime = 1.5f;
                break;

        }
        StartCoroutine(DestroyLasser());
    }

    void Update()
    {
        switch (_type)
        {
            case LasserType.horizontal:
                transform.Translate(Vector2.right * _speed * Time.deltaTime);
                _destroyTime = 0.5f;
                break;

            case LasserType.vertical:
                transform.Translate(Vector2.up * _speed * Time.deltaTime);
                _destroyTime = 1f;
                break;

        }
        
        
    }
    IEnumerator DestroyLasser()
    {
      

        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Rock") 
            Destroy(this.gameObject);
    }
}
