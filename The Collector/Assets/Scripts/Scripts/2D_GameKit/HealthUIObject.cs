using TMPro;
using UnityEngine;
namespace TwoDGameKit
{
    public class HealthUIObject : UIObject
    {
        private TextMeshProUGUI healthText;
        private PlayerHealth playerHealth;
        // Start is called before the first frame update
        void Start()
        {
            var manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();
            manager.Subscribe(UINames.Health, this);

            healthText = GetComponent<TextMeshProUGUI>();
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

            // Set the starting health
            healthText.text = playerHealth.GetMaxHealth().ToString();
        }
        public override void UpdateInt(int number)
        {
            healthText.text = playerHealth.GetCurrentHealth().ToString();
        }
    }
}