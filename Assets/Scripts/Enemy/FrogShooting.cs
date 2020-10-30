using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogShooting : MonoBehaviour
{
    [Tooltip("Gun Position")][SerializeField] Transform gunPos;

    GameObject prefeb;
    ObjectPooler objectPooler;

    [SerializeField] float offset;

    [SerializeField] float timeBtwShots;
    [SerializeField] float startTimeBtwShots;

    private void Start() {
       objectPooler = ObjectPooler.instance;
   }
    public void Shoot()
    {
        // if(!target)
        //     return;

        // Vector2 distance = target.position - transform.position;
        // float rotZ = Mathf.Atan2(distance.y,distance.x) * Mathf.Rad2Deg;
        // transform.localRotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if(timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
            prefeb = objectPooler.SpawnFromPool("EnemyBullet", gunPos.position, transform.rotation);
            prefeb.GetComponent<Rigidbody2D>().velocity = transform.right * 7f;
            SoundManager.instance.FireSound();
        }
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
