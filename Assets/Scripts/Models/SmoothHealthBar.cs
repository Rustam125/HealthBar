using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Models
{
    public class SmoothHealthBar : HealthBar
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _delay = 0.7f;

        protected override void ChangeValue(float health)
        {
            StartCoroutine(ChangeSmoothlyValue(health));
        }

        private IEnumerator ChangeSmoothlyValue(float health)
        {
            float elapsedTime = 0;

            while (elapsedTime < _delay)
            {
                elapsedTime += Time.deltaTime;
                _slider.value = Mathf.MoveTowards(_slider.value, health, elapsedTime / _delay);
                yield return null;
            }
        }
    }
}