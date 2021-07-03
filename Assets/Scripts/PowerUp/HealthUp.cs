using UnityEngine;

public class HealthUp : PowerUp
{
    private float healthUpPoint = 50f;

    protected override void EffectToPlayer(GameObject player)
    {
        PlayerLife playerLife = player.GetComponent<PlayerLife>();
        playerLife.currentHealth.value += healthUpPoint;
    }
}
