using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimation
{
    public static PlayerAnimator instance;
    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            DontDestroyOnLoad(this);
        }
    }
    public override void Start()
    {
        base.Start();
    }
}
