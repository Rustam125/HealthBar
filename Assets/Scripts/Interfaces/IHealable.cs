namespace Interfaces
{
    public interface IHealable
    {
        public bool IsHealthFull { get; }
        
        public void Heal(float amount);
    }
}