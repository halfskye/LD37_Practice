using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerAbilities : MonoBehaviour {

    [SerializeField]
    private Transform bulletOrigin;
    public Transform getBulletOrigin() { return bulletOrigin; }

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
            _gear["Laser"].Use();
        }
        if (CheckSecondaryWeaponInput())
        {
            _gear["Bomb"].Use();
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

    public void UpdateGear()
    {
        foreach(PlayerGear gear in _gear.Values) {
            gear.Update();
        }
    }

    public void addGear(string name)
    {
        PlayerGear gear = PlayerGear.CreateGear(name);
        if (gear != null)
        {
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
}
