using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveFalseAfterSeconds : MonoBehaviour
{
    [SerializeField]
    private float _seconds;

    private void OnEnable()
    {
       StartCoroutine(SetActiveFalse());
    }

    IEnumerator SetActiveFalse()
    {
        yield return new WaitForSeconds(_seconds);
        this.gameObject.SetActive(false);
    }
}
