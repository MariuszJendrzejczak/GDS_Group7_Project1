using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField][Tooltip("Trasa punkt po punkcie dla lotu statku. Wprowadzana parametrami x i y ręcznie (z palca). Size określa wielkość listy punktów. Można wprowadzić ich dowolną ilość. Po osiągniędziu ostatniego punktu statek poleci do pierwszego (0) i będzie kontynłował w kółko.")] private List<Vector2> _pathPoints;
    [SerializeField][Tooltip("Trasa punkt po punkcie dla lotu statku. W liście znajdują się pola drag and drop dla parametru transport. Algorytm działa tak sami jak z punktami z palca.")] private List<Transform> _pathByTransform;
    private enum ChooseList { transferPoints, fingerPoints };
    [SerializeField][Tooltip("Listy wyboru, za którymi punktami (z palca czy objektami transport) ma podążać statek")] private ChooseList _list = new ChooseList();
    private GameObject currentList;
     

    private Vector2 _target, _position;
    [SerializeField][Tooltip("Prękość poruszania się przeciwnika w jednostkach unity na frame. Dlatego wartość jest tak niska. Zalecam Operować między wartościami 0.01 do 0.06")] private float _step = 0.04f;
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
