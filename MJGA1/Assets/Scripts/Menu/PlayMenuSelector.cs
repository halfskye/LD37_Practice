using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayMenuSelector : BaseMainMenuSelector
{

    // New
    public override void selectUp()
    {
        SceneManager.LoadScene("MainScene1");
    }

    // Load
    public override void selectRight()
    {

    }

    // Achievements
    public override void selectDown()
    {

    }

    // Back
    public override void selectLeft()
    {
        MainMenu.SetMainMenu();
    }
}
