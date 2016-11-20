using UnityEngine;
using System.Collections;

public class Player : Singleton<Player> {

    private GameObject _player = null;
    public GameObject getPlayer() { return _player; }

    private PlayerMovement _movement = null;
    public PlayerMovement getMovement() { return _movement; }

    private PlayerAbilities _abilities = null;
    public PlayerAbilities getAbilities() { return _abilities; }

    private PlayerHealth _health = null;
    public PlayerHealth getHealth() { return _health; }

    private void Awake()
    {
        // Retrieve the Player object from the Scene.
        _player = GameObject.FindGameObjectWithTag("Player");
        if (!_player)
        {
            Debug.LogError("ERROR: Shit's fucked. No Player object found.");
        }

        // Retrieve subsystems.
        _movement = _player.GetComponent<PlayerMovement>();
        _abilities = _player.GetComponent<PlayerAbilities>();
        _health = _player.GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        AddStartingGear();
    }

    private void AddStartingGear()
    {
        _abilities.addGear("Laser", 1);
        _abilities.addGear("Bomb", 1);
        _abilities.addGear("Shield", 1);
    }

    public void takeDamage(float damage)
    {
        // Check against Shield first.
        PlayerShield shield = GetShield();
        if (shield != null)
        {
            damage = shield.TakeDamage(damage);
        }

        if (damage > 0.0f)
        {
            _health.takeDamage(damage);
        }
    }

    public PlayerShield GetShield()
    {
        // Check against Shield first.
        PlayerGear shieldGear;
        if (_abilities.getPlayerGear().TryGetValue("Shield", out shieldGear))
        {
            return (PlayerShield)shieldGear;
        }
        else
        {
            return null;
        }
    }

    public float GetShieldValue()
    {
        PlayerShield shield = GetShield();
        return (shield != null) ? shield.GetValue() : 0.0f;
    }

    public float GetHealthValue()
    {
        return _health.GetValue();
    }
}
