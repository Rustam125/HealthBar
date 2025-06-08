using TMPro;
using UnityEngine;

namespace Models
{
    public class TextHealthDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;

        public void SetHealth(float currentHealth, float maxHealth)
        {
            healthText.text = $"{currentHealth}/{maxHealth}";
        }
    }
}