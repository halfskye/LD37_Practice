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
        if (Player.Instance != null)
        {
            _gear = new Dictionary<string, PlayerGear>();
        }
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKey(PRIMARY_WEAPON_KEY))
        {
            _gear["Laser"].Use();
        }
        if (Input.GetKeyDown(SECONDARY_WEAPON_KEY))
        {
            _gear["Bomb"].Use();
        }
    }

    public void addGear(string name)
    {
        //@TODO: Find gear type by name and it. Probably some type of dictionary?
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
