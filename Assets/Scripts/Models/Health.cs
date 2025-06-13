using System;
using Interfaces;
using UnityEngine;

namespace Models
{
    public class Health : MonoBehaviour, IDamageable, IHealable
    {
        private const float MaxValue = 100;
        private const float MinValue = 0;

        [SerializeField] private float _value = 100;

        private bool _isDead;

        public event Action<float, float> ValueChanged;


        private void Start()
        {
            ValueChanged?.Invoke(_value, MaxValue);
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0 || _isDead)
            {
                return;
            }

            _value = Mathf.Clamp(_value - damage, MinValue, MaxValue);
            _isDead = Mathf.Approximately(_value, MinValue);
            ValueChanged?.Invoke(_value, MaxValue);
        }

        public void Heal(float amount)
        {
            if (amount <= 0 || _value >= MaxValue || _isDead)
            {
                return;
            }

            _value = Mathf.Clamp(_value + amount, MinValue, MaxValue);
            ValueChanged?.Invoke(_value, MaxValue);
        }
    }
}