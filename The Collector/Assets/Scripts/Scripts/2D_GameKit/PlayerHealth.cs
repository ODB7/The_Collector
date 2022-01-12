using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TwoDGameKit
{
    public class PlayerHealth : MonoBehaviour
    {
        private int maxHealth = 50;
        public int GetMaxHealth() => maxHealth;
        private int currentHealth;
        public int GetCurrentHealth() => currentHealth;
        private PlayerController controller;
        private UIManager uIManager;
        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            controller = GetComponent<PlayerController>();
            uIManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();

        }

        public void TakeDamage(int amount)
        {
            Debug.Log("I have taken " + amount + " of damage");
            // Decrease current health
            currentHealth -= amount;
            // Update UI
            var manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();
            manager.UpdateUI(UINames.Health, -amount);
            // Tell controller we are dead if we are
            if(currentHealth <= 0)
            {
                controller.Died();
            }
        }
    }
}