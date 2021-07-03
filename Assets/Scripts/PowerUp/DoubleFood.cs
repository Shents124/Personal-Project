using UnityEngine;

public class DoubleFood : PowerUp
{
   protected override void EffectToPlayer(GameObject player)
   {
      Shooting playerShooting = player.GetComponent<Shooting>();
      playerShooting.isShootingDouble = true;
      playerShooting.isShootingTriple = false;
      timeCountDownPowerUp -= Time.deltaTime;
        
      if (timeCountDownPowerUp <= 0)
      {
         playerShooting.isShootingDouble = false;
      }
   }
}
