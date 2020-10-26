using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEffect : MonoBehaviour
{
   public float time = 1;

   private void OnEnable(){
       DestroyObject(this.gameObject,time);
   }
}
