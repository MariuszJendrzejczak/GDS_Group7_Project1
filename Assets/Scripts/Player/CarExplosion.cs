using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosion : MonoBehaviour
{
    private Collider2D _frontFrame, _backFrame;
    private Animator _animator;

    private void Awake()
    {

    }

    public void CarExplodionAnim()
    {
        _frontFrame = GameObject.Find("MovementFrameLeft").GetComponent<Collider2D>();
        _backFrame = GameObject.Find("MovementFrameRight").GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();


        _backFrame.enabled = false;
        _frontFrame.enabled = false;

        StartCoroutine(CarDestroyAnimation());
    }


    IEnumerator CarDestroyAnimation()
    {
        Time.timeScale = 0.5f;
        for (int i = 0; i < transform.childCount -1; i++)
        {
            transform.GetChild(i).GetComponent<WheelExplosion>().ThrowWheels();
        }
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Debug.Log("Kurwa");
        _backFrame.enabled = true;
        _frontFrame.enabled = true; 
        GameManager.Instance.PlayerDestroyerd();
    }


}
