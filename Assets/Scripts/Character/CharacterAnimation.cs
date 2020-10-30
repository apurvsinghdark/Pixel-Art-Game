using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Animator animator;

    public virtual void Start() {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
}
