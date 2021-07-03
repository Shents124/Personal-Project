using System.Collections;
using UnityEngine;

public class DoubleFood : PowerUp
{
   protected override IEnumerator EffectToPlayer(GameObject player)
   {
      Shooting playerShooting = player.GetComponent<Shooting>();
      playerShooting.isShootingDouble = true;
      playerShooting.isShootingTriple = false;

      yield return new WaitForSeconds(timeCountDownPowerUp);
      playerShooting.isShootingDouble = false;
      Destroy(this.gameObject);
   }
}
