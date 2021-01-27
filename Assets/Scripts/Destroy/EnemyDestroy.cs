using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    private enum ScoreType { ufo1, ufo2, ufo3 }
    [SerializeField] private ScoreType _scoreType;
    [SerializeField]
    private int _ufo1Dst, _ufo2Dst, _ufo3Dst;
    [SerializeField]
    private GameObject _destroyAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Lasser")
        {
            switch (_scoreType)
            {
                case ScoreType.ufo1:
                    UIManager.Instance.UpdatePlayerScore(_ufo1Dst);
                    break;
                case ScoreType.ufo2:
                    UIManager.Instance.UpdatePlayerScore(_ufo2Dst);
                    break;
                case ScoreType.ufo3:
                    UIManager.Instance.UpdatePlayerScore(_ufo3Dst);
                    break;
            }
            Instantiate(_destroyAnim, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        if (collision.tag == "Player")
        {
            PlayerDestroy.Instance.DestroyPlayer();
            Instantiate(_destroyAnim, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
           
    }
}
