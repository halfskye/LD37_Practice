using UnityEngine;
using System.Collections;

public class Splash : BaseMainMenuItem {

    private enum SplashState
    {
        ALPHA_IN = 0,
        MOVE_UP = 1,
        DONE = 2,
    }
    private SplashState _state;

    [SerializeField]
    private SpriteRenderer _logo = null;

    // Alpha In properties
    [SerializeField]
    private float _TIME_TO_FULL_ALPHA = 2.0f;
    private float _alphaInTime = 0.0f;

    // Move Up properties
    [SerializeField]
    private float _TIME_BEFORE_MOVE_UP = 1.0f;
    private float _preMoveUpTime = 0.0f;
    [SerializeField]
    private float _MOVE_UP_SPEED = 1.0f;
    private const float _MOVE_UP_DESTINATION = 9.0f;

    public bool IsDone() { return (_state == SplashState.DONE);  }

	// Use this for initialization
	private void Start () {
        StartAlphaIn();
	}
	
	// Update is called once per frame
	private void Update () {
        Debug.Log(_state);
        UpdateState();
	}

    private void UpdateState()
    {
        switch (_state)
        {
            case SplashState.ALPHA_IN:
                {
                    UpdateAlphaIn();
                }
                break;
            case SplashState.MOVE_UP:
                {
                    UpdateMoveUp();
                }
                break;
            case SplashState.DONE:
                {
                    // Wait to be rescued?
                }
                break;
            default:
                {
                    Debug.LogError("State not recognized.");
                }
                break;
        }
    }

    private void StartAlphaIn()
    {
        _state = SplashState.ALPHA_IN;

        Color colorNoAlpha = _logo.color;
        colorNoAlpha.a = 0.0f;
        _logo.color = colorNoAlpha;
        _alphaInTime = 0.0f;
    }

    private void UpdateAlphaIn()
    {
        // Alpha Logo In
        if (_alphaInTime < _TIME_TO_FULL_ALPHA)
        {
            Color colorAlpha = _logo.color;
            colorAlpha.a = (_alphaInTime / _TIME_TO_FULL_ALPHA);
            _logo.color = colorAlpha;

            _alphaInTime += Time.deltaTime;
        }
        else
        {
            //@TODO: Go to next state.
            _state = SplashState.MOVE_UP;
        }
    }

    private void StartMoveUp()
    {
        _state = SplashState.MOVE_UP;

        _TIME_BEFORE_MOVE_UP = 0.0f;
    }

    private void UpdateMoveUp()
    {
        // Alpha Logo In
        if (_preMoveUpTime < _TIME_BEFORE_MOVE_UP)
        {
            _preMoveUpTime += Time.deltaTime;
        }
        else
        {
            Vector3 logoPos = _logo.transform.position;
            if (logoPos.y < _MOVE_UP_DESTINATION)
            {
                _logo.transform.position += (Vector3.up * Time.deltaTime * _MOVE_UP_SPEED);
            }
            else
            {
                Debug.Log("MAIN SCREEN TURNON?");
                // We done, trigger next step.
                _state = SplashState.DONE;
            }
        }
    }
}
