using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManu : MonoBehaviour
{

    [SerializeField]
    private GameObject _creditsPanel, _controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredits()
    {
        _creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        _creditsPanel.SetActive(false);
    }

    public void ShowControls()
    {
        _controls.SetActive(true);
    }

    public void HideControls()
    {
        _controls.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
