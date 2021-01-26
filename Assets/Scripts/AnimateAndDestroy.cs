using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAndDestroy : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(AnimateMe());
    }

    IEnumerator AnimateMe()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }
}
