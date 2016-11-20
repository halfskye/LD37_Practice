using UnityEngine;
using System.Collections;

public class PlayerBomb : PlayerWeapon {

    const float COOLDOWN_TIME_S = 2.0f;

    public PlayerBomb(int level)
    {
        SetType(Type.SECONDARY_WEAPON);
        SetLevel(level);

        setCooldown(COOLDOWN_TIME_S);
    }

    public override bool Fire()
    {
        //@TODO: Take into account the Bomb's level and do different behavior.

        GameObject bomb = (GameObject)GameObject.Instantiate(Resources.Load("Bomb"));
        Transform bulletOrigin = Player.Instance.getAbilities().getBulletOrigin();
        bomb.transform.position = bulletOrigin.transform.position;

        GameObject.Destroy(bomb, 3f);

        return true;
    }


}
