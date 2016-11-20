using UnityEngine;
using System.Collections;

public class PlayerShield : PlayerGear {

    private const float MAX_SHIELD = 50.0f;
    private const float REGEN_RATE = 10.0f;

    private float _shield;

    private void Start()
    {
        _shield = MAX_SHIELD;
    }

    public override void Update()
    {
        _shield += (REGEN_RATE * Time.deltaTime);
    }

    public override void Use()
    {
        // Do nothing.
    }
}
