using UnityEngine;
using System.Collections;

abstract public class PlayerWeapon : PlayerGear {
    private float _cooldown = 0.0f;
    public float getCooldown() { return _cooldown; }
    public void setCooldown(float cooldown) { _cooldown = cooldown; }

    private float _cooldownTime = 0.0f;

    public override void Update()
    {
        _cooldownTime += Time.deltaTime;
    }

    public override void Use()
    {
        if(CanFire()) {
            if (Fire())
            {
                _cooldownTime = 0.0f;
            }
        }
    }

    abstract public bool Fire();

    virtual public bool CanFire() {
        //@TODO: Check for things like cooldown, ammo, etc.
        return (_cooldownTime > _cooldown);
    }
}
