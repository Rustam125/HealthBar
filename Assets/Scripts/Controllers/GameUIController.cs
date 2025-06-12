using Models;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class GameUIController : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Button _takeDamageButton;
        [SerializeField] private Button _healButton;
        [SerializeField] private float _damageValue = 10f;
        [SerializeField] private float _healValue = 15f;

        public void Awake()
        {
            _takeDamageButton.onClick.AddListener(PerformDamage);
            _healButton.onClick.AddListener(PerformHeal);
        }

        private void PerformDamage()
        {
            _health.TakeDamage(_damageValue);
        }

        private void PerformHeal()
        {
            _health.Heal(_healValue);
        }
    }
}
