using UnityEngine;

public class Dragon : Animal,IDamageable
{
    public ParticleSystem dirt;
    
    private float maxDistanceRange = 20f;
    private float minDistanceRange = 15f;
    private float rangeAttack = 5f;
    private float runSpeed = 18f;
    private float flySpeed = 22f;
    
    private Animator dragonAnimator;
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Sleep = Animator.StringToHash("Sleep");

    protected override void OnEnable()
    {
        maxHealth = healthDragon;
        currentHealth = maxHealth;
        dragonAnimator = GetComponent<Animator>();
        speed = runSpeed;
        dame = 15;
        base.OnEnable();
    }

    protected override void Update()
    {
        this.transform.LookAt(playerTransform);
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer >= maxDistanceRange)
        {
            dragonAnimator.SetBool(IsRun,false);
            speed = flySpeed;
        }
        if(distanceToPlayer <= minDistanceRange)
        {
            dragonAnimator.SetBool(IsRun,true);
            speed = runSpeed;
            dirt.Play();
        }

        if (distanceToPlayer <= rangeAttack )
        {
            dragonAnimator.SetTrigger(Attack);
            speed = 0;
        }
    }

    public void TakeDame(int amountOfDame)
    {
        currentHealth -= amountOfDame;
        if (currentHealth <= 0)
        {
            DestroyGameObject();
            healthDragon += 50;
            EventBroker.CallUpdateScore(pointScore);
            SoundManager.Instance.PlaySound(SoundManager.Instance.bossDead);
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
