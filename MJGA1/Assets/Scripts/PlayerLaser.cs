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

        switch (GetLevel())
        {
            case 1:
                return FireLevel1();
                
            case 2:
                return FireLevel2();

            default:
                break;
        }

        return true;
    }

    public bool FireLevel1()
    {
        //@TODO: Take into account the Laser's level and do different behavior.
                
        Transform bulletOrigin = Player.Instance.getAbilities().getBulletOrigin();
        CreateBullet(bulletOrigin);
        return true;
    }

    public bool FireLevel2()
    {
        //@TODO: Take into account the Laser's level and do different behavior.

        Transform bulletOriginLeft = Player.Instance.getAbilities().getBulletOriginLeft();
        CreateBullet(bulletOriginLeft);

        Transform bulletOriginRight = Player.Instance.getAbilities().getBulletOriginRight();
        CreateBullet(bulletOriginRight);
        return true;
    }

    private void CreateBullet(Transform pos)
    {
        GameObject bullet = (GameObject)GameObject.Instantiate(Resources.Load("Bullet"));

        bullet.transform.position = pos.transform.position;
        GameObject.Destroy(bullet, 1.2f);

    }

}
