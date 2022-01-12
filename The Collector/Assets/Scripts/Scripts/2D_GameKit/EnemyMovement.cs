using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TwoDGameKit
{
    public class EnemyMovement : MonoBehaviour
    {
        private static GameObject playerObject;
        [SerializeField, Range(1,10)]
        private float speed = 5.0f;
        [SerializeField, Range(1, 10)]
        private float stopDistance = 5.0f;
        // Start is called before the first frame update
        void Start()
        {
            if(playerObject == null)
            {
                // Look for our player
                playerObject = GameObject.FindWithTag("Player");
            }
        }

        // Update is called once per frame
        void Update()
        {
            // Testing
            MoveToPlayer();
        }
        private void MoveToPlayer()
        {
            // Check for distance to player
            float distance = Vector2.Distance(transform.position, playerObject.transform.position);
            if(distance < stopDistance)
            {
                return;
            }

            // Find out which way the player is
            float direction = 0.0f;
            if(playerObject.transform.position.x> transform.position.x)
            {
                direction = 1.0f;
            }
            else if(playerObject.transform.position.x < transform.position.x)
            {
                direction = -1.0f;
            }
            // Move that way
            transform.Translate(Vector3.right * direction * Time.deltaTime * speed);
        }
    }
}