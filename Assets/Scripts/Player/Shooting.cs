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
    private float _cooldownTimeHorizontal, _cooldownTimeVertical;
    private bool _cooldownHorizontal = false, _cooldownVertical = false;

    private void Start()
    {

    }

    private void OnEnable()
    {
        _cooldownHorizontal = false;
        _cooldownVertical = false;
    }
    // Update is called once per frame
    void Update()
    {
        _OffsetHorizontal = new Vector2(this.transform.position.x + _posXHorizontalOffset, this.transform.position.y + _posYHorizontalOffset);
        _OffsetVertical = new Vector2(this.transform.position.x + _posXVerticalOffset, transform.position.y + _posYVerticalOffset);
       
        
       if (Input.GetKeyDown(KeyCode.L))
       {
            if (_cooldownHorizontal == false)
            {
                Instantiate(_lasserHorizontal, _OffsetHorizontal, Quaternion.identity);
                _cooldownHorizontal = true;
                AudioManager.Instanse.AudioCarShoot();
                StartCoroutine(CoolDownHorizontal());
            }
            if (_cooldownVertical == false)
            {
                Instantiate(_lasserVertical, _OffsetVertical, Quaternion.identity);
                _cooldownVertical = true;
                AudioManager.Instanse.AudioCarShoot();
                StartCoroutine(CoolDownVertical());
            }



       }
     
       
    }

    IEnumerator CoolDownHorizontal()
    {
        yield return new WaitForSeconds(_cooldownTimeHorizontal);
        _cooldownHorizontal = false;
    }
    IEnumerator CoolDownVertical()
    {
        yield return new WaitForSeconds(_cooldownTimeVertical);
        _cooldownVertical = false;
    }
}