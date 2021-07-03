using UnityEngine;

public class Shield : PowerUp
{
   protected override void EffectToPlayer(GameObject player)
   {
      PlayerLife playerLife = player.GetComponent<PlayerLife>();
      playerLife.isHasShield = true;
      playerLife.shieldEffect.Play();
      timeCountDownPowerUp -= Time.deltaTime;
        
      if (timeCountDownPowerUp <= 0)
      {
         playerLife.isHasShield = false;
         playerLife.shieldEffect.Stop();
      }
   }
}
