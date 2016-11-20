using UnityEngine;
using System.Collections;

public class PlayerBomb : PlayerWeapon {

    const float COOLDOWN_TIME_S = 2.0f;

    public PlayerBomb()
    {
        setCooldown(COOLDOWN_TIME_S);
    }

    public override bool Fire()
    {
        //@TODO: Create some bomb object.
        return true;
    }
}
