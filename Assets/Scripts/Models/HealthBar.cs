using UnityEngine;

namespace Models
{
    public abstract class HealthBar : MonoBehaviour
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
        
        protected float GetMaxHealth() => _health.GetMaxValue();

        protected abstract void ChangeValue(float health);
    }
}