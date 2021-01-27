using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private static ProgressBar _instance;
    public static ProgressBar Instance
    {
        get { return _instance; }
    }

    [SerializeField]
    private Slider _sliderAE, _sliderEJ, _sliderJO, _sliderOT, _sliderTZ;
    private Slider _currentSlider;
    [SerializeField]
    private GameObject _ballA, _ballE, _ballJ, _ballO, _ballT, _ballZ;
    private GameObject _currentBall;
    private int _counter;
    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SceneUpdateValues();
    }

    private void SceneUpdateValues()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                _currentSlider = _sliderAE;
                _currentBall = _ballE;
                break;
            case 2:
                _currentSlider = _sliderEJ;
                _currentBall = _ballJ;
                break;
            case 3:
                _currentSlider = _sliderJO;
                _currentBall = _ballO;
                break;
            case 4:
                _currentSlider = _sliderOT;
                _currentBall = _ballT;
                break;
            case 5:
                _currentSlider = _sliderTZ;
                _currentBall = _ballZ;
                break;

        }
    }
    public void SliderUpdate(int value)
    {
        _currentSlider.value += value;
        _counter += value;
    }

    public void ActivateProgressBall()
    {
        _currentBall.SetActive(true);
    }
    public void AfterRespawnSliderUpdate()
    {
        _currentSlider.value -= _counter;
        _counter = 0;
    }

    public void ResetCounter()
    {
        _counter = 0;
    }
}
