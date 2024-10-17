using Collectibles;
using EventSystems;
using Player;
using UnityEngine;

namespace Potions {
    public class HealthPotion : Collectible {
        [SerializeField] private HealthPotionConfig _healthPotionConfig;
        protected override void Collect() {
            GameEventSystem.HealPlayer(_healthPotionConfig.HealAmount);
            
            Destroy(gameObject);
        }
    }
}