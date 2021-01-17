﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    private enum ScoreType { small, medium, big}
    [SerializeField] private ScoreType _scoreType;
    [SerializeField]
    private int _smallDst, _mediumDst, _bigDst, _smallJump, _medJump, _bigJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerDestroy.Instance.DestroyPlayer();
            SpawnManager.Instance.AddDestroyerObjToList(this.gameObject);
            gameObject.SetActive(false);
            
        }
        if (collision.tag == "Lasser")
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
                

            gameObject.SetActive(false);
        }


    }

}
