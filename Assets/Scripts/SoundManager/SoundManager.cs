using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] battleSounds;
    public AudioClip collectingItem;
    public AudioClip bossAppearSound;
    public AudioClip bossDead;
    public AudioClip gameOver;
    public AudioClip ending;
    public AudioClip hitSound;

    public AudioSource spawnAudio;
    private AudioSource audioSource;
    
    
    private static SoundManager _instance;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("SoundManager is null!");
            return _instance;
        }
    }
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this;
        audioSource = GetComponent<AudioSource>();
    }
    
    public void PlayBattleSound( AudioClip sound)
    {
        spawnAudio.clip = sound;
        spawnAudio.Play();
        spawnAudio.loop = true;
    }

    public void StopPlayBattleSound()
    {
        spawnAudio.Stop();
    }
    
    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound); 
    }

    public AudioClip GetRandomBattleSound()
    {
        int index = Random.Range(0, battleSounds.Length);
        return battleSounds[index];
    }
}
