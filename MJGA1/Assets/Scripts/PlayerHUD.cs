using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI()
    {
        Player player = Player.Instance;

        int ScreenX = 10;
        int ScreenXWidth = 100;
        int ScreenY = Screen.height - 100;
        int SpaceBetweenEntries = 10;
        GUI.Label(new Rect(ScreenX, ScreenY, ScreenX + ScreenXWidth, ScreenY + SpaceBetweenEntries), string.Format("SHIELD: {0}", player.GetShieldValue()));
        ScreenY += SpaceBetweenEntries;
        GUI.Label(new Rect(ScreenX, ScreenY, ScreenX + ScreenXWidth, ScreenY + SpaceBetweenEntries), string.Format("HEALTH: {0}", player.GetHealthValue()));
        ScreenY += SpaceBetweenEntries;
    }
}
