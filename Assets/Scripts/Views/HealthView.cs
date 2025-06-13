using Models;
using UnityEngine;

namespace Views
{
    public abstract class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.ValueChanged += ChangeValue;
        }

        private void OnDisable()
        {
            _health.ValueChanged -= ChangeValue;
        }
        
        protected abstract void ChangeValue(float health, float maxHealth);
    }
}