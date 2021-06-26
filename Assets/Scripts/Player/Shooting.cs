using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool isShootingDouble = false;
    public bool isShootingTriple = false;
    
    [SerializeField] private Transform shootingPos;
    [SerializeField] private Transform shootingPosDoubleFirst;
    [SerializeField] private Transform shootingPosDoubleSecond;
    
    // Update is called once per frame
    private void Update()
    {
       if(Input.GetButtonDown("Fire1"))
           Shoot();
    }

    private void Shoot()
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;
         if (Physics.Raycast(ray, out hit))
         {
             Vector3 fireDir = ( hit.point - transform.position ).normalized;
             if (isShootingDouble)
             {
                 ShootingDoubleBullet(fireDir);
             }
             else if(isShootingTriple)
             {
                 ShootingTripleBullet(fireDir);
             }
             else
             {
                 ShootingDefault(fireDir);
             }
         }
    }

    private void ShootingDefault(Vector3 fireDirection)
    {
        GameObject bullet = PoolManager.Instance.RequestFood();
        bullet.transform.position = shootingPos.position;
        // Assign moveDirection of bullet
        bullet.GetComponent<Food>().moveDirection = fireDirection;
        bullet.GetComponent<Food>().playerPosition = transform.position;
    }
    
    private void ShootingDoubleBullet(Vector3 fireDirection)
    {
        GameObject bullet1 = PoolManager.Instance.RequestFood();
        GameObject bullet2 = PoolManager.Instance.RequestFood();

        bullet1.transform.position = shootingPosDoubleFirst.position;
        bullet2.transform.position = shootingPosDoubleSecond.position;
        
        var position = transform.position;
        
        bullet1.GetComponent<Food>().moveDirection = fireDirection;
        bullet1.GetComponent<Food>().playerPosition = position;
        
        bullet2.GetComponent<Food>().moveDirection = fireDirection;
        bullet2.GetComponent<Food>().playerPosition = position;
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
        Vector3 fireDirectionLeft = Quaternion.AngleAxis(-15, Vector3.up) * fireDirection;
        
        bullet1.GetComponent<Food>().moveDirection = fireDirectionLeft;
        bullet1.GetComponent<Food>().playerPosition = position1;
        
        Vector3 fireDirectionRight = Quaternion.AngleAxis(15, Vector3.up) * fireDirection;
        
        bullet2.GetComponent<Food>().moveDirection = fireDirectionRight;
        bullet2.GetComponent<Food>().playerPosition = position1;
        
        bullet3.GetComponent<Food>().moveDirection = fireDirection;
        bullet3.GetComponent<Food>().playerPosition = position1;
    }
}

