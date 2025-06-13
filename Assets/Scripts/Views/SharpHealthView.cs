using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class SharpHealthView : HealthView
    {
        [SerializeField] private Slider _slider;
        
        protected override void ChangeValue(float health, float maxHealth)
        {
            _slider.value = health / maxHealth;
        }
    }
}