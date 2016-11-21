using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

    enum State
    {
        SPLASH = 0,
        MAIN = 1,
        PLAY = 2,
    }
    private State _state;

    [SerializeField]
    private List<Splash> _splashScreens = null;
    private int _splashIndex = 0;

    [SerializeField]
    private Transform _menuCenter = null;

    [SerializeField]
    private BaseMainMenuSelector _mainMenuSelector = null;
    [SerializeField]
    private BaseMainMenuSelector _playMenuSelector = null;

    [SerializeField]
    private bool _skipSplash = false;

	// Use this for initialization
	private void Start () {
        if (!_skipSplash)
        {
            StartSplashScreens();
        }
        else
        {
            StartMainMenu();
        }
	}

    private void StartSplashScreens()
    {
        _state = State.SPLASH;
        _splashIndex = 0;
        StartSplashScreen(_splashIndex);
    }

    private void StartSplashScreen(int index)
    {
        _splashScreens[_splashIndex].gameObject.SetActive(true);
    }

    private void StartMainMenu()
    {
        _state = State.MAIN;
        _menuCenter.gameObject.SetActive(true);
        _mainMenuSelector.gameObject.SetActive(true);
    }

    private void DeactivateMainMenu()
    {
        _mainMenuSelector.gameObject.SetActive(false);
    }

    private void StartPlayMenu()
    {
        _state = State.PLAY;
        _menuCenter.gameObject.SetActive(true);
        _playMenuSelector.gameObject.SetActive(true);
    }

    private void DeactivatePlayMenu()
    {
        _playMenuSelector.gameObject.SetActive(false);
    }

	private void Update () {
        UpdateState();
	}

    private void UpdateState()
    {
        switch(_state)
        {
            case State.SPLASH:
                {
                    UpdateSplashScreens();
                }
                break;
            case State.MAIN:
                {
                    UpdateMainMenus();
                }
                break;
        }
    }

    private void UpdateSplashScreens() {
        if (_splashScreens[_splashIndex].IsDone())
        {
            _splashScreens[_splashIndex].gameObject.SetActive(false);
            ++_splashIndex;
            if (_splashIndex < _splashScreens.Count)
            {
                StartSplashScreen(_splashIndex);
            }
            else
            {
                StartMainMenu();
            }
        }
    }

    private void UpdateMainMenus()
    {

    }

    static public void SetMainMenu()
    {
        MainMenu mainMenu = GameObject.FindObjectOfType<MainMenu>();
        mainMenu.DeactivatePlayMenu();
        mainMenu.StartMainMenu();
    }

    static public void SetPlayMenu()
    {
        MainMenu mainMenu = GameObject.FindObjectOfType<MainMenu>();
        mainMenu.DeactivateMainMenu();
        mainMenu.StartPlayMenu();
    }
}
