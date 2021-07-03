using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isShootingDouble = false;
    public bool isShootingTriple = false;
    public Joystick rightJoystick;
    
    [SerializeField] private Transform shootingPos;
    [SerializeField] private Transform shootingPosDoubleFirst;
    [SerializeField] private Transform shootingPosDoubleSecond;
    [SerializeField] private float shootTimeDelay = 0.2f;
    
    private float shootHorizontalInput;
    private float shootVerticalInput;
    private float rotationSpeed = 1200f;
    private Vector3 shootDirection;
    private float yAngleRotationShoot = 15f;
    
    private float startShootTimeDelay;

    private void Start()
    {
        startShootTimeDelay = shootTimeDelay;
    }

    // Update is called once per frame
    private void Update()
    {
        shootHorizontalInput = rightJoystick.Horizontal;
        shootVerticalInput = rightJoystick.Vertical;

        shootDirection = new Vector3(shootHorizontalInput, 0, shootVerticalInput);
        shootDirection.Normalize();
        
        startShootTimeDelay -= Time.deltaTime;
        if (startShootTimeDelay <= 0)
        {
            if (shootDirection != Vector3.zero)
            {
                Shoot();
            }

            startShootTimeDelay = shootTimeDelay;
        }
        
        RotatePlayer();
    }
    
    private void RotatePlayer()
    {
        if (shootDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(shootDirection, Vector3.up);

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot()
    {
        if (isShootingDouble)
        {
            ShootingDoubleBullet(shootDirection);
        }
        else if (isShootingTriple)
        {
            ShootingTripleBullet(shootDirection);
        }
        else
        {
            ShootingDefault(shootDirection);
        }
    }

    private void ShootingDefault(Vector3 fireDirection)
    {
        GameObject bullet = PoolManager.Instance.RequestFood();
        bullet.transform.position = shootingPos.position;

        Food bulletFood = bullet.GetComponent<Food>();

        bulletFood.moveDirection = fireDirection;
        bulletFood.playerPosition = transform.position;
    }

    private void ShootingDoubleBullet(Vector3 fireDirection)
    {
        GameObject bullet1 = PoolManager.Instance.RequestFood();
        GameObject bullet2 = PoolManager.Instance.RequestFood();

        bullet1.transform.position = shootingPosDoubleFirst.position;
        bullet2.transform.position = shootingPosDoubleSecond.position;

        var position = transform.position;

        Food bullet1Food = bullet1.GetComponent<Food>();
        bullet1Food.moveDirection = fireDirection;
        bullet1Food.playerPosition = position;

        Food bullet2Food = bullet2.GetComponent<Food>();
        bullet2Food.moveDirection = fireDirection;
        bullet2Food.playerPosition = position;
    }

    private void ShootingTripleBullet(Vector3 fireDirection)
    {
        GameObject bullet1 = PoolManager.Instance.RequestFood();
        GameObject bullet2 = PoolManager.Instance.RequestFood();
        GameObject bullet3 = PoolManager.Instance.RequestFood();

        var position = shootingPos.position;
        bullet1.transform.position = position;
        bullet2.transform.position = position;
        bullet3.transform.position = position;

        var position1 = transform.position;

        Food bullet1Food = bullet1.GetComponent<Food>();
        bullet1Food.moveDirection = fireDirection;
        bullet1Food.playerPosition = position1;

        Vector3 fireDirectionLeft = Quaternion.Euler(0, -yAngleRotationShoot, 0) * fireDirection;

        Food bullet2Food = bullet2.GetComponent<Food>();
        bullet2Food.moveDirection = fireDirectionLeft;
        bullet2Food.playerPosition = position1;

        Vector3 fireDirectionRight = Quaternion.Euler(0, yAngleRotationShoot, 0) * fireDirection;

        Food bullet3Food = bullet3.GetComponent<Food>();
        bullet3Food.moveDirection = fireDirectionRight;
        bullet3Food.playerPosition = position1;
    }
}