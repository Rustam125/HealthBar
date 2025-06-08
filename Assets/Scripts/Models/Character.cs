using Interfaces;
using UnityEngine;

namespace Models
{
    public abstract class Character : MonoBehaviour, IDamageable, IHealable
    {
        [SerializeField] protected float maxHealth = 100f;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private TextHealthDisplay _textHealthDisplay;
        [SerializeField] private SmoothHealthBar _smoothHealthBar;

        protected float currentHealth;
        public bool IsHealthFull { get; }

        public float CurrentHealth => currentHealth;
        public float MaxHealth => maxHealth;


        protected virtual void Awake()
        {
            currentHealth = maxHealth;
            InitializeHealthBar();
        }

        protected void InitializeHealthBar()
        {
            _healthBar.SetMaxHealth(maxHealth);
            _healthBar.SetHealth(currentHealth);
            _smoothHealthBar.SetMaxHealth(maxHealth);
            _smoothHealthBar.SetHealth(currentHealth);
            _textHealthDisplay.SetHealth(currentHealth, maxHealth);
        }

        public virtual void TakeDamage(float damage)
        {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
            UpdateHealthDisplay();

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void UpdateHealthDisplay()
        {
            _healthBar?.SetHealth(currentHealth);
            _smoothHealthBar?.SetHealth(currentHealth);
            _textHealthDisplay?.SetHealth(currentHealth, maxHealth);
        }
        
        public void Heal(float amount)
        {
            if (IsHealthFull)
            {
                return;
            }

            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            UpdateHealthDisplay();
        }
        
        protected abstract void Die();
    }
}
