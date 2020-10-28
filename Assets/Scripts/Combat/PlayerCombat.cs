using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
   public float fireRate = 0.3f;
   float nextFire = 1f;
   ObjectPooler objectPooler;
   [SerializeField] Transform gunPoint;
   GameObject prefeb;

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
        prefeb = objectPooler.SpawnFromPool("Bullet", gunPoint.position, transform.rotation);
        prefeb.GetComponent<Rigidbody2D>().velocity = transform.right * 7f;
   }
}
