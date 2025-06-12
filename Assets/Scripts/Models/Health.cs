using System;
using Interfaces;
using UnityEngine;

namespace Models
{
    public class Health : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] private float _value = 100;

        private const float MaxValue = 100;
        private const float MinValue = 0;
        private bool _isDead;

        public event Action<float> ValueChanged;
        

        private void Start()
        {
            ValueChanged?.Invoke(_value);
        }
        
        public float GetMaxValue() => MaxValue; 

        public void TakeDamage(float damage)
        {
            if (damage > 0)
            {
                _value -= damage;

                if (_value <= MinValue)
                {
                    _value = MinValue;
                    _isDead = true;
                }
            }

            ValueChanged?.Invoke(_value);
        }

        public void Heal(float amount)
        {
            if (amount <= 0 || _value >= MaxValue || _isDead)
            {
                return;
            }

            _value += amount;

            if (_value > MaxValue)
            {
                _value = MaxValue;
            }

            ValueChanged?.Invoke(_value);
        }
    }
}