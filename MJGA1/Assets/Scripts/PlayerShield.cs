﻿using UnityEngine;
using System.Collections;

public class PlayerShield : PlayerGear {

    private const float MAX_SHIELD = 50.0f;
    private const float REGEN_RATE = 10.0f;

    private float _shield;
    public float GetValue() { return _shield; }

    public PlayerShield()
    {
        _shield = MAX_SHIELD;
    }

    public override void Update()
    {
        _shield += (REGEN_RATE * Time.deltaTime);
        _shield = Mathf.Clamp(_shield, 0.0f, MAX_SHIELD);
    }

    public override void Use()
    {
        // Do nothing.
    }

    public bool HasShield()
    {
        return !Mathf.Approximately(_shield, 0.0f);
    }

    // Returns how much damage it wasn't able to sap.
    public float TakeDamage(float damage)
    {
        if (_shield > damage)
        {
            _shield -= damage;
            return 0.0f;
        }
        else
        {
            float damageLeftOver = damage - _shield;
            _shield = 0.0f;
            return damageLeftOver;
        }
    }
}
