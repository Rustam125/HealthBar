using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class SharpHealthBar : HealthBar
    {
        [SerializeField] private Slider _slider;
        
        protected override void ChangeValue(float health)
        {
            _slider.value = health;
        }
    }
}