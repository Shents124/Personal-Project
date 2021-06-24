using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public LayerMask ground;
    
    private float horizontalInput;
    private float verticalInput;

    private float speedMultiplier = 1.5f;
    private bool isSpeedUp = false;
    
    private float maxDistance = 50f;
    
    private Rigidbody _playerRb;

    [SerializeField] private float currentStamina;
    [SerializeField] private float maxStamina = 50;
    public StaminaUI staminaUI;
    private bool isHasStamina = true;
    
    // Start is called before the first frame update
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        currentStamina = maxStamina;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        verticalInput = Input.GetAxis("Vertical") * speed;

        // Increase speed when hold LeftShift key
        if (Input.GetKey(KeyCode.LeftShift) && !isSpeedUp  && isHasStamina)
        {
            speed *= speedMultiplier;
            isSpeedUp = true;
        }

        // Set speed to default when don't hold LeftShift key any more
        if (Input.GetKeyUp(KeyCode.LeftShift) && isSpeedUp)
        {
            speed /= speedMultiplier;
            isSpeedUp = false;
        }
        UpdateStamina();
    }
    
    private void FixedUpdate()
    {
        Move();
        RotatePlayer();
    }

    private void Move()
    {
        _playerRb.velocity = new Vector3(horizontalInput * Time.deltaTime, _playerRb.velocity.y,
            verticalInput * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, ground))
        {
            // Player look at mouse position
            transform.LookAt(hit.point);
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
            speed /= 2;
        }
        else
            isHasStamina = true;
        
        staminaUI.UpdateStamina(currentStamina,maxStamina);
    }
}
