using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothness = 0.5f;

    [SerializeField] Vector3 offset;

    private void Start() {
        target = GameObject.FindObjectOfType<CharacterMovement>().transform;

        
    }

    private void FixedUpdate() {
        if(!target)
            return;

        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothness);
    }
}
