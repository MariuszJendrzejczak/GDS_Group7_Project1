using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAndDestroy : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private bool _withSound;


    void Start()
    {
        _animator = GetComponent<Animator>();
        if (_withSound)
            AudioManager.Instanse.DestroyUfo();
        StartCoroutine(AnimateMe());
    }

    IEnumerator AnimateMe()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(this.gameObject);
    }
}
