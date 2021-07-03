using System.Collections;
using UnityEngine;

public class Shield : PowerUp
{
    protected override IEnumerator EffectToPlayer(GameObject player)
    {
        PlayerLife playerLife = player.GetComponent<PlayerLife>();
        playerLife.isHasShield = true;
        playerLife.shieldEffect.Play();
        
        yield return new WaitForSeconds(timeCountDownPowerUp);
        playerLife.isHasShield = false;
        playerLife.shieldEffect.Stop();
        Destroy(this.gameObject);
    }
}