using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageHeal
{
    void GetDamage( int damage );

    void AddHealth( Item heal );
}
