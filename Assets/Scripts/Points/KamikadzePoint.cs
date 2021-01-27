using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikadzePoint : MonoBehaviour
{
    private enum UfoType { Ufo1, Ufo2, Ufo3}
    [SerializeField][Tooltip("Wybierz który typ Ufo ma przejść w tryb Kamikadze")]
    private UfoType _ufoType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnemyStateManager.Instance.mode = EnemyStateManager.Mode.Attack;
            switch (_ufoType)
            {
                case UfoType.Ufo1:
                    SpawnManager.Instance.EnemyStateKamikadzeUfo1();
                    break;
                case UfoType.Ufo2:
                    SpawnManager.Instance.EnemyStateKamikadzeUfo2();
                    break;
                case UfoType.Ufo3:
                    SpawnManager.Instance.EnemyStateKamikadzeUfo3();
                    break;
            }
            
        }
    }
 
}
