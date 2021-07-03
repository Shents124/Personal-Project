using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected float timeCountDownPowerUp = 10f;
    private string playerTag = "Player";
    
    protected virtual void EffectToPlayer(GameObject player)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            SpawnPowerUpManager.amountOfPowerUp--;
            Destroy(this.gameObject);
            EffectToPlayer(other.gameObject);
            SoundManager.Instance.PlaySound(SoundManager.Instance.collectingItem);
        }
    }
}
