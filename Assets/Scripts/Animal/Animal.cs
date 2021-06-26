using UnityEngine;

public class Animal : MonoBehaviour
{
    public Transform playerTransform;
    
    [SerializeField] protected int pointScore;
    [SerializeField] protected int dame = 5;
    [SerializeField] protected float speed;
    
    protected int currentHealth;
    protected int maxHealth;
    protected int healthDragon = 200;
    
    private Vector3 direction;
    private Rigidbody animalRb;
    private float timeDelay;
    
    protected virtual void OnEnable()
    {
        timeDelay = 1.5f;
        EventBroker.GameOver += StopFollowingPlayer;
        EventBroker.GameOver += StopPlaySoundEffect;
    }

    private void OnDisable()
    {
        EventBroker.GameOver -= StopFollowingPlayer;
        EventBroker.GameOver -= StopPlaySoundEffect;
    }

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponentInChildren<Rigidbody>();
    }

    protected virtual void Update()
    {
        // Look at player
        this.transform.LookAt(playerTransform);
    }

    private void FixedUpdate()
    {
        timeDelay -= Time.deltaTime;
        if (timeDelay <= 0)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        direction = (playerTransform.position - transform.position).normalized;
        // Add velocity
        animalRb.velocity = direction * speed;
    }
    
    private void StopFollowingPlayer()
    {
        gameObject.GetComponent<Animal>().enabled = false;
        gameObject.GetComponent<Animator>().enabled = false;
    }

    private void StopPlaySoundEffect()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<IDamageable>().TakeDame(dame);
        }
    }
}
