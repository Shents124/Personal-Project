using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public StaminaUI staminaUI;
    public SpeedUpUI speedUpUI;
    public LayerMask ground;
    public Joystick leftJoystick;

    private float speed;
    private float speedDefault = 650f;
    
    private float maxStamina = 10;
    private float currentStamina;
    private float speedMultiplier = 1.5f;
    
    private bool isSpeedUp = false;
    private bool isHasStamina = true;
    
    private float horizontalInput;
    private float verticalInput;
    
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    
    private static readonly int SpeedF = Animator.StringToHash("Speed_f");

    // Start is called before the first frame update
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        currentStamina = maxStamina;
        speed = speedDefault;
    }

    private void Update()
    {
        isSpeedUp = speedUpUI.isSelected;
        horizontalInput = leftJoystick.Horizontal * speed;
        verticalInput = leftJoystick.Vertical * speed;
        
        UpdateSpeed();
        UpdateStamina();
        UpdateAnimation();
    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        playerRigidbody.velocity = new Vector3(horizontalInput * Time.deltaTime, playerRigidbody.velocity.y,
            verticalInput * Time.deltaTime);
    }

    private void UpdateAnimation()
    {
        if (Mathf.Abs(verticalInput) > 0 && Mathf.Abs(horizontalInput) > 0)
        {
            if(isSpeedUp)
                playerAnimator.SetFloat(SpeedF,1f);
            playerAnimator.SetFloat(SpeedF,0.75f);
        }
        else
            playerAnimator.SetFloat(SpeedF,0f);
    }
    
    private void UpdateSpeed()
    {
        if (isHasStamina)
        {
            if (isSpeedUp)
            {
                speed = speedDefault * speedMultiplier;
            }
            else
            {
                speed = speedDefault;
            }
        }
        else 
        {
            if (isSpeedUp)
            {
                speed = speedDefault / speedMultiplier;
            }
            playerAnimator.SetFloat(SpeedF,0.25f);
        }
        
    }
    private void UpdateStamina()
    {
        if (isSpeedUp)
        {
            currentStamina -= Time.deltaTime;
        }
        else
        {
            currentStamina += Time.deltaTime;
            if (currentStamina >= maxStamina)
                currentStamina = maxStamina;
        }
        
        if (currentStamina <= 0)
        {
            isHasStamina = false;
            currentStamina = 0;
        }
        else
            isHasStamina = true;
        staminaUI.UpdateStamina(currentStamina,maxStamina);
    }
}
