using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _lasserHorizontal, _lasserVertical;

    private Vector2 _OffsetHorizontal, _OffsetVertical;
    [SerializeField]
    private float _posXHorizontalOffset, _posYHorizontalOffset, _posXVerticalOffset, _posYVerticalOffset;
    [SerializeField]
    private float _cooldownTime = 1f;
    private bool _cooldown = false;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _OffsetHorizontal = new Vector2(this.transform.position.x + _posXHorizontalOffset, this.transform.position.y + _posYHorizontalOffset);
        _OffsetVertical = new Vector2(this.transform.position.x + _posXVerticalOffset, transform.position.y + _posYVerticalOffset);
        if (_cooldown == false)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Instantiate(_lasserHorizontal, _OffsetHorizontal, Quaternion.identity);
                Instantiate(_lasserVertical, _OffsetVertical, Quaternion.identity);
                _cooldown = true;
                StartCoroutine(CoolDown());
            }
        }
       
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(_cooldownTime);
        _cooldown = false;
    }
}