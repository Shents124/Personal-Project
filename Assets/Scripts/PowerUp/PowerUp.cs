using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected float timeCountDownPowerUp = 10f;
    private string playerTag = "Player";
    
    protected virtual IEnumerator EffectToPlayer(GameObject player)
    {
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            SpawnPowerUpManager.amountOfPowerUp--;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(EffectToPlayer(other.gameObject));
            SoundManager.Instance.PlaySound(SoundManager.Instance.collectingItem);
        }
    }
}
