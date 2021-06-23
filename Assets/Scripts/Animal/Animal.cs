using UnityEngine;
using UnityEngine.Serialization;

public class Animal : MonoBehaviour,IDamageable
{
    public static int healthDragon = 200;
    [SerializeField] protected float speed;
    public Transform playerTransform;

    protected int currentHealth;
    protected int maxHealth;
    [SerializeField] protected int point;
    protected Vector3 direction;
    private Rigidbody _animalRb;

    private float timeDelay;

    protected virtual void OnEnable()
    {
        timeDelay = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animalRb = GetComponentInChildren<Rigidbody>();
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
        _animalRb.velocity = direction * speed;
    }

    public virtual void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SpawnAnimal.amountOfAnimal--;
            Debug.Log(SpawnAnimal.amountOfAnimal);
            EventBroker.CallUpdateScore(point);
            EventBroker.CallUpdateCountAnimal();
        }
    }
}
