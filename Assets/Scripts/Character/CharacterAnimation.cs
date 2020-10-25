using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public static CharacterAnimation instance;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
            instance = this;
        }
    }
    public Animator animator;

    private void Start() {
        animator = GetComponentInChildren<Animator>();
    }
}
