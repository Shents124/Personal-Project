using UnityEngine;
public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform shootingPos;
    // Update is called once per frame
    void Update()
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
             // 
             Vector3 fireDir = ( hit.point - transform.position ).normalized;
             // Instance sandwich
             GameObject bullet = PoolManager.Instance.RequestFood();
             // set 
             bullet.transform.position = shootingPos.position;
             // Assign moveDirection of sandwich
             bullet.GetComponent<Food>().moveDirection = fireDir;
             bullet.GetComponent<Food>().playerPosition = transform.position;
         }
    }
}

