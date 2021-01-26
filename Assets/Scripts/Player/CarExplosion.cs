using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosion : MonoBehaviour
{
    private Collider2D _frontFrame, _backFrame;
    private Animator _animator;

    void Start()
    {
        _frontFrame = GameObject.Find("MovementFrameLeft").GetComponent<Collider2D>();
        _backFrame = GameObject.Find("MovementFrameRight").GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();


        _backFrame.enabled = false;
        _frontFrame.enabled = false;

        StartCoroutine(CarDestroyAnimation());
    }


    void Update()
    {
 
        
    }
    IEnumerator CarDestroyAnimation()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        GameManager.Instance.PlayerDestroyerd();
        _backFrame.enabled = true;
        _frontFrame.enabled = true;
        Destroy(this.gameObject);
    }
}
