using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TwoDGameKit
{
    public class ShootSpawner : MonoBehaviour
    {
        // Object prefab for the projectile
        [SerializeField] private GameObject projectilePrefab;
        // Delay timer
        [SerializeField] private float delayTimer;
        // Timer
        private float timer;
        // Start is called before the first frame update
        void Start()
        {
            timer = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            // Check for button down and if the timer is less then or equil to 0
            if (Input.GetMouseButtonDown(0) && timer <= 0.0f)
            {
                Debug.Log("Shooting Sound");
                timer = delayTimer;
                var direction = Vector2.Angle(transform.position, MousePosition.mouseWorldPosition);
                // Create the projectile
                Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0,0,direction));
            }
            timer -= Time.deltaTime;

        }
    }
}