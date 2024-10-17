using System;

namespace EventSystems {
    public static class GameEventSystem
    {
        public static event Action<int> OnPlayerHeal;
        public static event Action<int> OnPlayerHealthUpdate;

        public static void HealPlayer(int HealAmmount)
        {
            OnPlayerHeal?.Invoke(HealAmmount);
        }
        public static void UpdatePlayerHealth(int currentHealth)
        {
            OnPlayerHealthUpdate?.Invoke(currentHealth);
        }
            
        
    }
}