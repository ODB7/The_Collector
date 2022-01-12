using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
    /// <summary>
    /// Physics bade 2D movement that expects Gravity
    /// Base functionality includes left and right movement as well as jumping
    /// And falling
    /// When we move we will tell the Animation Controller to update
    /// When we jump we will tell the Animation Controller to update
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement2D : MonoBehaviour
    {
        /// ----------
        /// Public Scalars
        /// ----------
        // Movement based values we want to change without bringing up code
        [Header("Movement")]
        [SerializeField, Range(0.0f, 10.0f),
            Tooltip("Top velocity in units/second")]
        private float topSpeed = 1.0f;

        [SerializeField, Range(0.0f, 5.0f),
            Tooltip("Time to full speed in seconds")]
        private float acclerationTime = 1.25f;

        [SerializeField,
            Tooltip("Acceleration Curve")]
        private AnimationCurve accelerationCurve;

        [SerializeField, Range(0.0f, 5.0f),
            Tooltip("Time to full stop in seconds")]
        private float deacclerationTime = 1.25f;

        [SerializeField,
            Tooltip("Deacceleration Curve")]
        private AnimationCurve deaccelerationCurve;

        // Force applied to a jump
        public float jumpForce;

        // 2D Rigidbody
        private Rigidbody2D rigidbody;

        
        private bool isOnGround = true;
        private bool isMoving = false;

        // Start is called before the first frame update
        void Start()
        {
            // Attach all the references we know about
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void LateUpdate()
        {
            // If we are not updating movement this frame, than slow us down
            if (!isMoving)
            {
                SlowDown();
            }
            isMoving = false;
        }

        /// <summary>
        /// Handle movement
        /// </summary>
        /// <param name="direction">Direction of travel, positive is right </param>
        internal void Move(float direction)
        {
            // Set the moving to true for this frame
            isMoving = true;

            // Get the adjusted velocity using a curve
            float velocityX = SpeedAdjustment(acclerationTime, accelerationCurve, false);
            // Apply force of the direction of travel 
            rigidbody.velocity += new Vector2(velocityX * direction, 0);
        }
        /// <summary>
        /// Method for slowing the charactor down if we are moving and
        /// the movement buttons are not being pressed
        /// (not pressing left or right)
        /// </summary>
        private void SlowDown()
        {
            float direction = 0.0f;
            if(rigidbody.velocity.x > 0) // Going to the right
            {
                direction = 1.0f;
            }
            else                        // Going to the left
            {
                direction = -1.0f;
            }
            // Find the slope down velocity 
            float velocityX = SpeedAdjustment(deacclerationTime, deaccelerationCurve, true);
            rigidbody.velocity += new Vector2(velocityX * direction, 0);
        }
        /// <summary>
        /// Calulate the speed change from the current speed using the next step
        /// in the given speed curve 
        /// </summary>
        /// <param name="speedStep"></param>
        /// <param name="speedCurve"></param>
        /// <param name="isSlowingDown"></param>
        /// <returns>The value of the speed change based on the speed curve position</returns>

        private float SpeedAdjustment(float speedStep, AnimationCurve speedCurve, bool isSlowingDown)
        {
            /* 1) Find the current position on the speed curve
             * 2) Adjust the to the next position by the step amount * time.deltatime
             * 3) Return the adjusted speed
             */
            // Return value for the velocity change
            float velocityChange = 0.0f;

            // Determine the size of the step
            float stepSize = (1.0f / speedStep) * Time.deltaTime;
            // 1.a Find the current velocity
            float currentVelocity = Mathf.Abs(rigidbody.velocity.x);
            // If we have stopped and we are slowing down, than we are done
            if(currentVelocity == 0.0f && isSlowingDown)
            {
                return 0.0f;
            }
            // Assume that we are not trying to slow down
            float speedCurvePosition = 0.0f;
            // If we are currently moving but have no velocity then make the current
            // position the next step
            if(currentVelocity == 0.0f)
            {
                speedCurvePosition = stepSize;
            }
            else
            {
                // Raw Position
                speedCurvePosition = currentVelocity / topSpeed;
                // Adjust the position
                if (isSlowingDown)
                {
                    speedCurvePosition -= speedStep;
                }
                else
                {
                    speedCurvePosition += speedStep;
                }
            }
            float newSpeed = topSpeed * speedCurve.Evaluate(speedCurvePosition);
            velocityChange = newSpeed - currentVelocity;
            return velocityChange;
        }

        /// <summary>
        /// Add force up if we are grounded
        /// </summary>
        internal void Jump()
        {
            if (isOnGround)
            {
                rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                // Set is on ground to false
                isOnGround = false;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                isOnGround = true;
            }
            /* Other Collision */

        }
    }