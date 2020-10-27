using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   public float fireRate = 0.3f;
   float nextFire = 1f;
   ObjectPooler objectPooler;
   [SerializeField] Transform gunPoint;

   private void Start() {
       objectPooler = ObjectPooler.instance;
   }

    private void FixedUpdate() {
        if (fireRate == 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
            } 
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot ();
            }
        }
    }
   void Shoot()
   {
       GameObject Bullets = objectPooler.SpawnFromPool("Bullet", gunPoint.position, transform.rotation);
   }
}
