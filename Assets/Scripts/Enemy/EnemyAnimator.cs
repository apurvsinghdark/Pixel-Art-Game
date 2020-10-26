using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : CharacterAnimation
{
    public static EnemyAnimator instance;
    private void Awake() {
        if(instance == null)
            instance = this; 
    }
    public override void Start()
    {
        base.Start();
    }
}
