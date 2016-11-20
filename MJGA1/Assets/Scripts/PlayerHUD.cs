using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerHUD : MonoBehaviour {

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
        //_healthSpriteRenderer = new SpriteRenderer();
        _healthSpriteRenderer.sprite = _healthSprites[_healthSprites.Count-1];
        //_shieldSpriteRenderer = new SpriteRenderer();
        _shieldSpriteRenderer.sprite = _shieldSprites[_shieldSprites.Count-1];
    }

	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
        _healthSpriteRenderer.sprite = GetAppropriateHealthSprite();
        _shieldSpriteRenderer.sprite = GetAppropriateShieldSprite();
	}

    private Sprite GetAppropriateHealthSprite()
    {
        float health = Player.Instance.GetHealthValue();
        float healthRatio = health / PlayerHealth.MAX_HEALTH;
        int healthIndex = Mathf.FloorToInt(healthRatio * (_healthSprites.Count-1));
        return _healthSprites[healthIndex];
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
