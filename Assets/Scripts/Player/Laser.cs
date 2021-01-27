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
    [SerializeField]
    private float _destroyTime;

    [SerializeField][Tooltip("Szybkość poruszania się lasera. Zasięg w sekundach laserów")]
    private float _speed = 8.0f, _horizontalRange, _verticalRange;


    // Update is called once per frame
    private void Start()
    {
        switch (_type)
        {
            case LasserType.horizontal:
                _destroyTime = _horizontalRange;
                break;

            case LasserType.vertical:
                _destroyTime = _verticalRange;
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
