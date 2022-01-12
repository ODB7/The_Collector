using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDGameKit
{
    /// <summary>
    /// Player controller is th emain interface for dealing with players input
    /// We can jump and accecpt damage or buffs through the players controller
    /// Used for accepting inputs from the player on the character
    /// </summary>
    [RequireComponent(typeof(Simple2DMovement))]
    public class PlayerController : MonoBehaviour
    {
        // Movement Controller
        private Simple2DMovement movement;
        private bool isDead = false;
        // Start is called before the first frame update
        void Start()
        {
            // Attach the Movement Controller
            movement = GetComponent<Simple2DMovement>();
            
        }
        // Update is called once per frame
        void Update()
        {
            CheckForPlayerInput();
           
        }
        //Check for any buttons press, lifted or held during this frame
        private void CheckForPlayerInput()
        {
            if (isDead)
            {
                return;
            }
            // Check for Inputs and activate corresponding actions
            // -----------------------------
            // Movement
            // -----------------------------

            // Horizontal Movement
            // If there is Hozizontal input( raw is -1.0, 0.0, or 1.0)
            Vector2 direction = new Vector2();
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            
            if(direction.magnitude != 0.0f)
            {
                movement.Move(direction);
            }

            // -----------------------------
            // Other Actions
            // -----------------------------
            /* More actions here */
        }

        public void Died()
        {
            isDead = true;
        }
    }
}