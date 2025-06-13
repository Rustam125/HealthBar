using TMPro;
using UnityEngine;

namespace Views
{
    public class TextHealthView : HealthView
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        protected override void ChangeValue(float health, float maxHealth)
        {
            _healthText.text = $"{health}/{maxHealth}";
        }
    }
}