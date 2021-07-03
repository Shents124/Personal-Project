using System.Collections;
using UnityEngine;

public class HealthUp : PowerUp
{
    private float healthUpPoint = 50f;

    protected override IEnumerator EffectToPlayer(GameObject player)
    {
        PlayerLife playerLife = player.GetComponent<PlayerLife>();
        playerLife.currentHealth.value += healthUpPoint;
        yield return null;
        Destroy(this.gameObject);
    }
}
