using UnityEngine;
using System.Collections;

public class PlayerLaser : PlayerWeapon {

    const float COOLDOWN_TIME_S = 0.1f;

    public PlayerLaser(int level)
    {
        SetType(Type.PRIMARY_WEAPON);
        SetLevel(level);

        setCooldown(COOLDOWN_TIME_S);
    }

    public override bool Fire()
    {
        //@TODO: Take into account the Laser's level and do different behavior.

        GameObject bullet = (GameObject)GameObject.Instantiate(Resources.Load("Bullet"));
        Transform bulletOrigin = Player.Instance.getAbilities().getBulletOrigin();
        bullet.transform.position = bulletOrigin.transform.position;

        GameObject.Destroy(bullet, 1.2f);

        return true;
    }
}
