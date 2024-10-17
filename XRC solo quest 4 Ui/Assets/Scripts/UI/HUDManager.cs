using TMPro;
using UnityEngine;
using EventSystems;
namespace UI {
    public class HUDManager : MonoBehaviour {
        [SerializeField] private TMP_Text _playerHealth;
    
        private void Awake() {
            GameEventSystem.OnPlayerHealthUpdate += UpdatePlayerHealth;
        }

        private void OnDestroy() {
            GameEventSystem.OnPlayerHealthUpdate -= UpdatePlayerHealth;
        }

        private void UpdatePlayerHealth(int currentHealth) {
            _playerHealth.text = $"{currentHealth}";
        }
    }
}