using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField][Tooltip("Trasa punkt po punkcie dla lotu statku. Wprowadzana parametrami x i y ręcznie (z palca). Size określa wielkość listy punktów. Można wprowadzić ich dowolną ilość. Po osiągniędziu ostatniego punktu statek poleci do pierwszego (0) i będzie kontynłował w kółko.")] 
    private List<Vector2> _pathPoints;
    [SerializeField][Tooltip("Trasa punkt po punkcie dla lotu statku. W liście znajdują się pola drag and drop dla parametru transport. Algorytm działa tak sami jak z punktami z palca.")] 
    private List<Transform> _pathByTransform;
    private enum ChooseList { transferPoints, fingerPoints, randomList };
    [SerializeField][Tooltip("Listy wyboru, za którymi punktami (z palca czy objektami transport) ma podążać statek")] 
    private ChooseList _list = new ChooseList();
 
    [SerializeField]
    private List<Transform> _currentList;
    [SerializeField]
    //private List<Transform> _track01, _track02, _track03, _track04, _track05, _track06;
    private List<List<Transform>> _allList;



    [SerializeField]
    private Vector2 _target, _position;
    [SerializeField][Tooltip("Prękość poruszania się przeciwnika w jednostkach unity na frame. Dlatego wartość jest tak niska. Zalecam Operować między wartościami 0.01 do 0.06")] private float _step = 0.04f;
    int counter = 0;
   // public ListOfTrackLists TrackListsVar = new ListOfTrackLists();


    void Start()
    {
        //_allList.Add(_track01); _allList.Add(_track02); _allList.Add(_track03); _allList.Add(_track04); _allList.Add(_track05); _allList.Add(_track06);
        switch (_list)
        {
            case ChooseList.fingerPoints:
                _target = _pathPoints[0];
                break;
            case ChooseList.transferPoints:
                _target = _pathByTransform[0].position;
                break;
            case ChooseList.randomList:
                _allList = ListOfTrackLists.Instance.InportLists();
                Debug.Log(_allList.Count);
                _currentList = _allList[Random.Range(0, _allList.Count)];
                _target = _currentList[0].position;
         
                
                break;
        }

        

    }


    public void Movement()
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

            case ChooseList.randomList:


                if (this.transform.position == _currentList[counter].position)
                {
                    counter++;
                    if (counter == _currentList.Count)
                        counter = 0;

                    _target = _currentList[counter].position;
                }

                break;

        }
    }
}
