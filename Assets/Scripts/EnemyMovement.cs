using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Vector2> _pathPoints;
    [SerializeField] private List<Transform> _pathByTransform;
    private enum ChooseList { transferPoints, fingerPoints };
    [SerializeField] private ChooseList _list = new ChooseList();
    private GameObject currentList;
     

    private Vector2 _target, _position;
    [SerializeField] private float _step = 0.04f;
    int counter = 0;


    void Start()
    {
        switch (_list)
        {
            case ChooseList.fingerPoints:
                _target = _pathPoints[0];
                break;
            case ChooseList.transferPoints:
                _target = _pathByTransform[0].position;
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        _position = this.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _target, _step);

        
        
        switch (_list)
        {
            case ChooseList.fingerPoints:
                if (_position == _pathPoints[counter])
                {
                    counter++;

                    if (counter == _pathPoints.Count)
                        counter = 0;

                    _target = _pathPoints[counter];

                }
                break;

            case ChooseList.transferPoints:

                if (this.transform.position == _pathByTransform[counter].position)
                {
                    counter++;

                    if (counter == _pathByTransform.Count)
                        counter = 0;

                    _target = _pathByTransform[counter].position;

                }
                break;
        }

    }
}
