using UnityEngine;

public enum PowerUpType{
    None,
    DoubleBullet,
    TripleBullet
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
}
