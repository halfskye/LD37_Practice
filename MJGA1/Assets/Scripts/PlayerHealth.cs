using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    static public float MAX_HEALTH = 50.0f;

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
            Destroy(Player.Instance.getPlayer().gameObject);
            _health = 0.0f;
        }
    }

    public void heal(float amount)
    {
        _health += amount;
        _health = Mathf.Clamp(_health, 0.0f, MAX_HEALTH);
    }

    void OnCollisionEnter2D(Collision2D Enemy)
    {
        if (Enemy.gameObject.tag == "Enemy")
        {
            const float randomTempDamage = 5.0f;
            Player.Instance.takeDamage(randomTempDamage);
        }
    }
}
