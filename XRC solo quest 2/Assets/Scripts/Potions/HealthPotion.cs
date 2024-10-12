using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Collectible
{
    [SerializeField] private HealthPotionConfig _healthPotionConfig;
    //TODO
    // BUG: ...
   
    
    protected override void Collect()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        playerHealth.heal(_healthPotionConfig.HealAmount);
        Destroy(gameObject);
    }
}
