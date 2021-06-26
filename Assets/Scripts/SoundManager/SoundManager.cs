using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] battleSounds;
    public AudioClip collectingItem;
    public AudioClip bossAppearSound;
    public AudioClip bossDead;
    public AudioClip gameOver;
    public AudioClip hitSound;
    
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
    
    public void PlayBattleSound(AudioSource aSource, AudioClip sound)
    {
        aSource.clip = sound;
        aSource.Play();
        aSource.loop = true;
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
