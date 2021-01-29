using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    private enum ScoreType { small, medium, big}
    [SerializeField] private ScoreType _scoreType;
    [SerializeField]
    private int _smallDst, _mediumDst, _bigDst;
    [SerializeField]
    private bool _isMine = false;
    [SerializeField]
    private GameObject _destroyAnim;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerDestroy.Instance.DestroyPlayer();
            SpawnManager.Instance.AddDestroyerObjToList(this.gameObject);
            if (_destroyAnim)
                Instantiate(_destroyAnim, transform.position, Quaternion.identity).transform.SetParent(GameObject.Find("Enviroment").transform.GetChild(0));
            gameObject.SetActive(false);
            
        }
        if (collision.tag == "Lasser")
        {
            if (_isMine == false)
            {
                SpawnManager.Instance.AddDestroyerObjToList(this.gameObject);
            switch (_scoreType)
            {
                case ScoreType.small:
                    UIManager.Instance.UpdatePlayerScore(_smallDst);
                    break;
                case ScoreType.medium:
                    UIManager.Instance.UpdatePlayerScore(_mediumDst);
                    break;
                case ScoreType.big:
                    UIManager.Instance.UpdatePlayerScore(_bigDst);
                    break;
            }
            if (_destroyAnim)
                {
                    Instantiate(_destroyAnim, transform.position, Quaternion.identity).transform.SetParent(GameObject.Find("Enviroment").transform.GetChild(0));
                    Debug.Log("Boom");
                }

            AudioManager.Instanse.AudioRockDestroy();
            gameObject.SetActive(false);
            }
            
        }


    }

}
