using UnityEngine;
using System.Collections;

abstract public class PlayerGear {
    public enum Type
    {
        NONE = 0,
        SHIELD = 1,
        PRIMARY_WEAPON = 2,
        SECONDARY_WEAPON = 3,
    };
    private Type _type = Type.NONE;
    public Type GetType() { return _type; }
    protected void SetType(Type type) { _type = type; }

    private int _level = 1;
    public int GetLevel() { return _level; }
    protected void SetLevel(int level) { _level = level; }

    abstract public void Use();
    abstract public void Update();

    static public PlayerGear CreateGear(string name, int level)
    {
        switch (name)
        {
            case "Laser":
                {
                    return new PlayerLaser(level);
                }
            case "Bomb":
                {
                    return new PlayerBomb(level);
                }
            case "Shield":
                {
                    return new PlayerShield(level);
                }
            default:
                Debug.LogError("ERROR: Didn't recognize Gear name.");
                return null;
        }
    }
}
