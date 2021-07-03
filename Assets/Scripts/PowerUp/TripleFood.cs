using System.Collections;
using UnityEngine;
public class TripleFood : PowerUp
{
    protected override IEnumerator EffectToPlayer(GameObject player)
    {
        Shooting playerShooting = player.GetComponent<Shooting>();
        playerShooting.isShootingTriple = true;
        playerShooting.isShootingDouble = false;
        
        yield return new WaitForSeconds(timeCountDownPowerUp);
        playerShooting.isShootingTriple = false;
        Destroy(this.gameObject);
    }
}
