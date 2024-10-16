using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Collectible : MonoBehaviour
{
   protected abstract void Collect();

   private void OnTriggerEnter2D(Collider2D other)
   {
      Collect();
   }
}
