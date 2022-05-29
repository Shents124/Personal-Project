using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;
        
        SoundManager.Instance.PlaySound(SoundManager.Instance.collectingItem);
        EventBroker.CallOnSpawnWave();
    }
}
