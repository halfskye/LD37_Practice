using UnityEngine;
using System.Collections;

abstract public class PlayerGear {
    abstract public void Use();
    abstract public void Update();

    static public PlayerGear CreateGear(string name)
    {
        switch (name)
        {
            case "Laser":
                {
                    return new PlayerLaser();
                }
            case "Bomb":
                {
                    return new PlayerBomb();
                }
            case "Shield":
                {
                    return new PlayerShield();
                }
            default:
                Debug.LogError("ERROR: Didn't recognize Gear name.");
                return null;
        }
    }
}
