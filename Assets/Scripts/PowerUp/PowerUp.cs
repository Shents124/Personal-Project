using UnityEngine;

public enum PowerUpType{
    None,
    HealthUp,
    Shield,
    DoubleBullet,
    TripleBullet
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
}
