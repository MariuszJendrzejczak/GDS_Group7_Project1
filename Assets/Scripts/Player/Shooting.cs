using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] [Tooltip("Pola drag and drop. Do umieszczania prefabów laserów, którymi będzie strzelał pojazd")] private GameObject _lasserHorizontal, _lasserVertical;
    private Vector2 _OffsetHorizontal, _OffsetVertical;
    [SerializeField][Tooltip("Ustawienia offsetu dla lasera. Czyli modyfikacja punktu względem pojazdu w którym lasery będą sie pojawiać")]
    private float _posXHorizontalOffset, _posYHorizontalOffset, _posXVerticalOffset, _posYVerticalOffset;
    [SerializeField][Tooltip("Czas przeładowania. Czas między wystrzałami, w którym nie da rady strzelać")]
    private float _cooldownTime = 1f;
    private bool _cooldown = false;

    private void Start()
    {

    }

    private void OnEnable()
    {
        _cooldown = false;
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
                AudioManager.Instanse.AudioCarShoot();
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