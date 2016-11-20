using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHUD : MonoBehaviour {

    private const bool DEBUG = false;

    private const int SPACE_FROM_SCREEN_EDGE = 0;

    [SerializeField]
    List<Sprite> _healthSprites = null;

    [SerializeField]
    private SpriteRenderer _healthSpriteRenderer;

    [SerializeField]
    List<Sprite> _shieldSprites = null;

    [SerializeField]
    private SpriteRenderer _shieldSpriteRenderer;

    private void Awake()
    {
        //@TODO: Create the Health and Shield Sprite Renderers.
        UpdateHealth();
        _shieldSpriteRenderer.sprite = _shieldSprites[_shieldSprites.Count-1];

        Debug.Log(_healthSpriteRenderer.transform.position);
    }
	
	// Update is called once per frame
	private void Update () {
        UpdateHealth();
        UpdateShield();
	}

    private void UpdateHealth()
    {
        _healthSpriteRenderer.sprite = GetAppropriateHealthSprite();
        //UpdateHealthLocation();
    }

    private void UpdateHealthLocation()
    {
        Vector3 screen = new Vector3(0, Screen.height);
        Vector3 offset = new Vector3(SPACE_FROM_SCREEN_EDGE, SPACE_FROM_SCREEN_EDGE);
        _healthSpriteRenderer.transform.position = screen + offset;
    }

    private Sprite GetAppropriateHealthSprite()
    {
        float health = Player.Instance.GetHealthValue();
        float healthRatio = health / PlayerHealth.MAX_HEALTH;
        int healthIndex = Mathf.FloorToInt(healthRatio * (_healthSprites.Count-1));
        return _healthSprites[healthIndex];
    }

    private void UpdateShield()
    {
        _shieldSpriteRenderer.sprite = GetAppropriateShieldSprite();
    }

    private Sprite GetAppropriateShieldSprite()
    {
        float shield = Player.Instance.GetShieldValue();
        float shieldRatio = shield / PlayerShield.MAX_SHIELD;
        int shieldIndex = Mathf.FloorToInt(shieldRatio * (_shieldSprites.Count-1));
        return _shieldSprites[shieldIndex];
    }

    private void OnGUI()
    {
        if (DEBUG)
        {
            Player player = Player.Instance;

            int ScreenX = 10;
            int ScreenXWidth = 100;
            int ScreenY = Screen.height - 100;
            int SpaceBetweenEntries = 12;
            GUI.Label(new Rect(ScreenX, ScreenY, ScreenX + ScreenXWidth, ScreenY + SpaceBetweenEntries), string.Format("SHIELD: {0:F2}", player.GetShieldValue()));
            ScreenY += SpaceBetweenEntries;
            GUI.Label(new Rect(ScreenX, ScreenY, ScreenX + ScreenXWidth, ScreenY + SpaceBetweenEntries), string.Format("HEALTH: {0:F2}", player.GetHealthValue()));
            ScreenY += SpaceBetweenEntries;
        }
    }
}
