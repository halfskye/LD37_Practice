using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    [SerializeField]
    private float MAX_HEALTH = 50.0f;

    private float _health;
    public float GetValue() { return _health; }

	// Use this for initialization
	void Start () {
        _health = MAX_HEALTH;
	}

    public void takeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0.0f)
        {
            //@TODO: Player is dead. Deal wit dat.
            // Maybe make an event that others can subscribe to?
        }
    }

    public void heal(float amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0.0f, MAX_HEALTH);
    }
}
