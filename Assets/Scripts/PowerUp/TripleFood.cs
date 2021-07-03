using UnityEngine;
public class TripleFood : PowerUp
{
    protected override void EffectToPlayer(GameObject player)
    {
        Shooting playerShooting = player.GetComponent<Shooting>();
        playerShooting.isShootingTriple = true;
        playerShooting.isShootingDouble = false;
        timeCountDownPowerUp -= Time.deltaTime;
        
        if (timeCountDownPowerUp <= 0)
        {
            playerShooting.isShootingTriple = false;
        }
    }
}
