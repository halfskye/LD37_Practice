using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerAbilities : MonoBehaviour {

    [SerializeField]
    private Transform bulletOrigin;
    public Transform getBulletOrigin() { return bulletOrigin; }

    [SerializeField]
    private SpriteRenderer _powerup1SpriteRenderer;
    [SerializeField]
    private SpriteRenderer _powerup2SpriteRenderer;
    [SerializeField]
    private SpriteRenderer _powerup3SpriteRenderer;

    [SerializeField]
    List<Sprite> _shieldSprites = null;
    [SerializeField]
    List<Sprite> _laserSprites = null;
    [SerializeField]
    List<Sprite> _bombSprites = null;

    private Dictionary<string, PlayerGear> _gear = null;
    public Dictionary<string, PlayerGear> getPlayerGear() { return _gear; }

    private const KeyCode PRIMARY_WEAPON_KEY = KeyCode.Space;
    private const KeyCode SECONDARY_WEAPON_KEY = KeyCode.M;

    void Awake()
    {
        _gear = new Dictionary<string, PlayerGear>();
    }

	// Update is called once per frame
	void Update () {
        UpdateGear();
        UpdatePlayerInput();
    }

    private void UpdatePlayerInput()
    {
        if (CheckPrimaryWeaponInput())
        {
            UsePrimaryWeapon();
        }
        if (CheckSecondaryWeaponInput())
        {
            UseSecondaryWeapon();
        }
    }

    private bool CheckPrimaryWeaponInput()
    {
        return Input.GetMouseButton(0) || Input.GetKey(PRIMARY_WEAPON_KEY);
    }

    private bool CheckSecondaryWeaponInput()
    {
        return Input.GetMouseButton(1) || Input.GetKey(SECONDARY_WEAPON_KEY);
    }

    private void UseGearType(PlayerGear.Type type)
    {
        foreach (PlayerGear gear in _gear.Values)
        {
            if (gear.GetType() == type)
            {
                gear.Use();
            }
        }
    }

    private void UsePrimaryWeapon()
    {
        UseGearType(PlayerGear.Type.PRIMARY_WEAPON);
    }

    private void UseSecondaryWeapon()
    {
        UseGearType(PlayerGear.Type.SECONDARY_WEAPON);
    }

    public void UpdateGear()
    {
        foreach(PlayerGear gear in _gear.Values) {
            gear.Update();
        }
    }

    public void addGear(string name, int level)
    {
        PlayerGear gear = PlayerGear.CreateGear(name, level);
        if (gear != null)
        {
            UpdatePowerupSprite(gear);
            _gear.Add(name, gear);
        }
        else
        {
            Debug.LogError(string.Format("Couldn't find gear by name: %s.", name));
        }
    }

    public void removeGear(string name)
    {
        if (_gear.ContainsKey(name))
        {
            _gear.Remove(name);
        }
        else
        {
            Debug.LogError(string.Format("Player didn't have gear %s", name));
        }
    }

    private void UpdatePowerupSprite(PlayerGear gear)
    {
        int levelIndex = gear.GetLevel() - 1;
        switch (gear.GetType())
        {
            case PlayerGear.Type.SHIELD:
                {
                    _powerup1SpriteRenderer.sprite = _shieldSprites[levelIndex];
                }
                break;
            case PlayerGear.Type.PRIMARY_WEAPON:
                {
                    _powerup2SpriteRenderer.sprite = _laserSprites[levelIndex];
                }
                break;
            case PlayerGear.Type.SECONDARY_WEAPON:
                {
                    _powerup3SpriteRenderer.sprite = _bombSprites[levelIndex];
                }
                break;
            case PlayerGear.Type.NONE:
            default:
                {
                    Debug.LogError("Gear Type not recognized.");
                }
                break;
        }
    }
}
