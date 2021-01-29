using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static  AudioManager Instanse
    {
        get { return _instance; }
    }

    [SerializeField]
    private List<AudioSource> _audioList;
    private int _childCount;
    void Awake()
    {
        _instance = this;

        _childCount = this.transform.childCount;
        for (int i = 0; i < _childCount; i++)
        {
            _audioList.Add(transform.GetChild(i).GetComponent<AudioSource>());
        }

    }
    // 0 - GameOver, 1 - ZPoint, 2 - MiddleCheckpoints, 3 - EndOdScenCheckPoint, 4 - RocketHole, 5 - CarJump, 6 - CarShoot, 7 - ReckDestroy, 8 - CarDestroy - 9 - DestroyUfo
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AudioGameOver()
    {
        _audioList[0].Play();
    }

    public void AudioZPoint()
    {
        _audioList[1].Play();
    }

    public void AudioMiddlePoint()
    {
        _audioList[2].Play();
    }

    public void AudioEndScenePoint()
    {
        _audioList[3].Play();
    }

    public void AudioRocketHole()
    {
        _audioList[4].Play();
    }

    public void AudioCarJump()
    {
        _audioList[5].Play();
    }

    public void AudioCarShoot()
    {
        _audioList[6].Play();
    }

    public void AudioRockDestroy()
    {
        _audioList[7].Play();
    }

    public void AudioCarDestroy()
    {
        _audioList[8].Play();
    }

    public void DestroyUfo()
    {
        _audioList[9].Play();
    }
}
