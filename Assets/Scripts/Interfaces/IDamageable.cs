namespace Interfaces
{
    public interface IDamageable
    {
        public float CurrentHealth { get; }
        
        public float MaxHealth { get; }
        
        public void TakeDamage(float amount);
    }
}