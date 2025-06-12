using TMPro;
using UnityEngine;

namespace Models
{
    public class TextHealthBar : HealthBar
    {
        [SerializeField] private TextMeshProUGUI _healthText;

        protected override void ChangeValue(float health)
        {
            _healthText.text = $"{health}/{GetMaxHealth()}";
        }
    }
}