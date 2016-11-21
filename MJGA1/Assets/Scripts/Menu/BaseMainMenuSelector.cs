using UnityEngine;
using System.Collections;

abstract public class BaseMainMenuSelector : BaseMainMenuItem {

    [SerializeField]
    private SpriteRenderer _upSpriteRenderer = null;
    [SerializeField]
    private SpriteRenderer _rightSpriteRenderer = null;
    [SerializeField]
    private SpriteRenderer _downSpriteRenderer = null;
    [SerializeField]
    private SpriteRenderer _leftSpriteRenderer = null;

    public abstract void selectUp();
    public abstract void selectRight();
    public abstract void selectDown();
    public abstract void selectLeft();

    private const KeyCode UP_KEY = KeyCode.W;
    private const KeyCode RIGHT_KEY = KeyCode.D;
    private const KeyCode DOWN_KEY = KeyCode.S;
    private const KeyCode LEFT_KEY = KeyCode.A;

    private void Update()
    {
        if (IsKeyPressed(UP_KEY))
        {
            selectUp();
        }
        else if (IsKeyPressed(RIGHT_KEY))
        {
            selectRight();
        }
        else if (IsKeyPressed(DOWN_KEY))
        {
            selectDown();
        }
        else if (IsKeyPressed(LEFT_KEY))
        {
            selectLeft();
        }
    }

    private bool IsKeyPressed(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }
}
