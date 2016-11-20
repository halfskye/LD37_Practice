using UnityEngine;
using System.Collections;

public class PlayerLaser : PlayerWeapon {

    public override bool Fire()
    {
        GameObject bullet = (GameObject)GameObject.Instantiate(Resources.Load("Bullet"));
        Transform bulletOrigin = Player.Instance.getAbilities().getBulletOrigin();
        bullet.transform.position = bulletOrigin.transform.position;

        GameObject.Destroy(bullet, 1.2f);

        return true;
    }
}
