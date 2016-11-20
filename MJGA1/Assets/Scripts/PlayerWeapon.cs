using UnityEngine;
using System.Collections;

abstract public class PlayerWeapon : PlayerGear {
    private float _cooldown = 0.0f;
    public float getCooldown() { return _cooldown; }
    public void setCooldown(float cooldown) { _cooldown = cooldown; }

    private float _cooldownTime = 0.0f;

    public override void Use()
    {
        _cooldownTime += Time.deltaTime;

        //base.Use();
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
        return true;
    }
}
