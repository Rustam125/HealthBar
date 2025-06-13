using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class SmoothHealthView : HealthView
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _delay = 0.5f;

        private Coroutine _coroutine;
        
        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
        
        protected override void ChangeValue(float health, float maxHealth)
        {
            _coroutine = StartCoroutine(ChangeSmoothlyValue(health / maxHealth));
        }

        private IEnumerator ChangeSmoothlyValue(float health)
        {
            float elapsedTime = 0;
            var previousValue = _slider.value;

            while (elapsedTime < _delay)
            {
                elapsedTime += Time.deltaTime;
                _slider.value = Mathf.Lerp(previousValue, health, elapsedTime / _delay);
                yield return null;
            }
        }
    }
}