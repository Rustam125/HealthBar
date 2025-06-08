using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class SmoothHealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _smoothSpeed = 5f;

        private float _targetHealth;
        
        private void Update()
        {
            _slider.value =
                Mathf.Abs(_slider.value - _targetHealth) > 0.1f ?
                    Mathf.Lerp(_slider.value, _targetHealth, _smoothSpeed * Time.deltaTime) : _targetHealth;
        }

        public void SetHealth(float health)
        {
            _targetHealth = health;
        }
        
        public void SetMaxHealth(float health)
        {
            _targetHealth = health;
            _slider.maxValue = health;
            _slider.value = health;
        }
    }
}