using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleShooting : MonoBehaviour
{
    public static EagleShooting instance;

    private void Awake() {
        if(instance == null )
            instance = this;
    }

    [Tooltip("Player Position")][SerializeField] Transform target;
    [Tooltip("Gun Position")][SerializeField] Transform gunPos;

    GameObject prefeb;
    [SerializeField] ObjectPooler objectPooler;

    [SerializeField] float offset;

    [SerializeField] float timeBtwShots;
    [SerializeField] float startTimeBtwShots;

    private void Start() {
       objectPooler = ObjectPooler.instance;

       target = GameObject.FindObjectOfType<CharacterMovement>().transform;
   }
    public void Shoot()
    {
        if(!target)
            return;

        Vector2 distance = target.position - transform.position;
        float rotZ = Mathf.Atan2(distance.y,distance.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if(timeBtwShots <= 0)
        {
            timeBtwShots = startTimeBtwShots;
            prefeb = objectPooler.SpawnFromPool("Bullet", gunPos.position, transform.rotation);
            prefeb.GetComponent<Rigidbody2D>().velocity = transform.right * 7f;
            SoundManager.instance.FireSound();
        }
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
