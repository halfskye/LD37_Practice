using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuSelector : BaseMainMenuSelector {

    // Play
    public override void selectUp()
    {
        MainMenu.SetPlayMenu();
    }

    // Store
    public override void selectRight()
    {

    }

    // Achievements
    public override void selectDown()
    {

    }

    // Exit
    public override void selectLeft()
    {
        Application.Quit();
    }
}
