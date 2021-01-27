using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikadzePoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField][Tooltip("Czas w kótrym ma zakończyć się Kamikadze i FlyMode. Wszystkie Ufoki obecne na scenie maja byc do tego czasu zniszczone.")]
    private float _timeForKamikadze;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnemyStateManager.Instance.mode = EnemyStateManager.Mode.Attack;
            SpawnManager.Instance.EnemyStateKamikadzePointUpdate();
        }
    }
 
}
