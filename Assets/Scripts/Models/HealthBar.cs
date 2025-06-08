using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        public void SetHealth(float health)
        {
            _slider.value = health;
        }

        public void SetMaxHealth(float health)
        {
            _slider.maxValue = health;
            _slider.value = health;
        }
    }
}