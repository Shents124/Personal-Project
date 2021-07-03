using UnityEngine;

public class Dragon : Animal,IDamageable
{
    public ParticleSystem dirt;
    
    private float maxDistanceRange = 20f;
    private float minDistanceRange = 15f;
    private float rangeAttack = 5f;
    private int runSpeed = 18;
    private int flySpeed = 22;
    private int healthBonus = 50;
    private float distanceToPlayer;
    
    private Animator dragonAnimator;
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Sleep = Animator.StringToHash("Sleep");

    protected override void OnEnable()
    {
        maxHealth = healthDragon;
        currentHealth = maxHealth;
        dragonAnimator = GetComponent<Animator>();
        dataAnimal.speed = runSpeed;
        base.OnEnable();
    }

    protected override void Update()
    {
        Transform dragonTransform = transform;
        dragonTransform.LookAt(playerTransform);
        distanceToPlayer = Vector3.Distance(dragonTransform.position, playerTransform.position);
        
        UpdateState();
        
        animalHealthBar.UpdateHealth(currentHealth);
    }

    public void TakeDame(int amountOfDame)
    {
        currentHealth -= amountOfDame;
        if (currentHealth <= 0)
        {
            animalHealthBar.gameObject.SetActive(false);
            DestroyGameObject();
            healthDragon += healthBonus;
            EventBroker.CallUpdateScore(dataAnimal.pointScore);
            SoundManager.Instance.PlaySound(SoundManager.Instance.bossDead);
        }
    }

    private void UpdateState()
    {
        if (distanceToPlayer >= maxDistanceRange)
        {
            dragonAnimator.SetBool(IsRun,false);
            dataAnimal.speed = flySpeed;
        }
        if(distanceToPlayer <= minDistanceRange)
        {
            dragonAnimator.SetBool(IsRun,true);
            dataAnimal.speed = runSpeed;
            dirt.Play();
        }

        if (distanceToPlayer <= rangeAttack )
        {
            dragonAnimator.SetTrigger(Attack);
            dataAnimal.speed = 0;
        }
    }
    
    private void DestroyGameObject()
    {
        Destroy(gameObject,3f);
        dragonAnimator.SetTrigger(Sleep);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Dragon>().enabled = false;
        SpawnAnimalManager.isSpawnDragon = false;
    }
}
