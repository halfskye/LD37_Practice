using UnityEngine;
using System.Collections;

public class Player : Singleton<Player> {

    private GameObject _player = null;
    public GameObject getPlayer() { return _player; }

    private MonoBehaviour _movement = null;
    public MonoBehaviour getMovement() { return _movement; }

    private MonoBehaviour _abilities = null;
    public MonoBehaviour getAbilities() { return _abilities; }

    private MonoBehaviour _health = null;
    public MonoBehaviour getHealth() { return _health; }

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
}
