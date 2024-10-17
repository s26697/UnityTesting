using System;
using EventSystems;
using Unity.VisualScripting;
using UnityEngine;

namespace Player {
    public class PlayerHealth : MonoBehaviour {
        [SerializeField] private PlayerConfig _playerConfig;

        private int _currentHealthValue;
        private int CurrentHealth {
            get => _currentHealthValue;
            set {
                _currentHealthValue = value;
                GameEventSystem.UpdatePlayerHealth(value);
            }
        }

        private void Awake() {
            
            GameEventSystem.OnPlayerHeal += Heal;
        }

        private void Start()
        {
            CurrentHealth = _playerConfig.BaseHealth;
        }

        private void OnDestroy()
        {
            GameEventSystem.OnPlayerHeal -= Heal;
        }

        public void Heal(int healAmount) {
            if (healAmount < 0) {
                return;
            }

            if (CurrentHealth + healAmount > _playerConfig.MaxHealth) {
                CurrentHealth = _playerConfig.MaxHealth;
                return;
            }

            CurrentHealth += healAmount;
        }
    }
}