using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosion2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _body, wheelfront, wheelmiddle, wheelback;

    private Collider2D _frontFrame, _backFrame;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _frontFrame = GameObject.Find("MovementFrameLeft").GetComponent<Collider2D>();
        _backFrame = GameObject.Find("MovementFrameRight").GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();


        _backFrame.enabled = false;
        _frontFrame.enabled = false;

        Time.timeScale = 0.5f;
        wheelback.GetComponent<WheelExplosion>().ThrowWheels();
        wheelmiddle.GetComponent<WheelExplosion>().ThrowWheels();
        wheelfront.GetComponent<WheelExplosion>().ThrowWheels();

        StartCoroutine(CarDestroyAnimation());
    }
   /* private void Update()
    {
        transform.Translate(Vector2.left * 0.98f * Time.deltaTime);
    }*/

    IEnumerator CarDestroyAnimation()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        _backFrame.enabled = true;
        _frontFrame.enabled = true;
        GameManager.Instance.PlayerDestroyerd();
        Destroy(gameObject);

    }
}
