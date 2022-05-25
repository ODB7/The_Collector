using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TwoDGameKit
{
    /// <summary>
    /// Player controller is th emain interface for dealing with players input
    /// We can jump and accecpt damage or buffs through the players controller
    /// Used for accepting inputs from the player on the character
    /// </summary>
    [RequireComponent(typeof(Movement2D))]
    public class PlayerController : MonoBehaviour
    {
        private static GameObject playerObject;
        // Movement Controller
        private Movement2D movement;
        private bool isDead = false;
        private Animator m_animator;
        private SpriteRenderer m_spriteRenderer;
        private string spawnLocationPrevious;
        private string spawnLocationToLoad;
        [SerializeField]private string spawnLocationDefault = "SpawnLocation";
        // Start is called before the first frame update
        void Start()
        {
            // Attach the Movement Controller
            movement = GetComponent<Movement2D>();
            m_animator = GetComponent<Animator>();
            m_spriteRenderer = GetComponent<SpriteRenderer>();

            DontDestroyOnLoad(gameObject);

            if(playerObject == null)
            {
                playerObject = gameObject;
            }
            else if(playerObject != gameObject)
            {
                Destroy(gameObject);
            }
            SceneManager.sceneLoaded += LoadedLevel;
        }

        private void LoadedLevel(Scene scene, LoadSceneMode mode)
        {
            GameObject loadLocation = GameObject.Find(spawnLocationToLoad);
            if (loadLocation != null)
            {
                transform.position = loadLocation.transform.position;
            }
            else
            {
                loadLocation = GameObject.Find(spawnLocationDefault);
                transform.position = loadLocation.transform.position;
            }
            movement.Move(Vector2.zero);
        }
        //when you leave a level we will store the name of the location you left from
        public void UpdateLeavingLocation(string locationName, string arrivingLocation = "")
        {
            spawnLocationToLoad = arrivingLocation;
            spawnLocationPrevious = locationName;
        }
        // Update is called once per frame
        void Update()
        {
            CheckForPlayerInput();
            float horizontalInput = Input.GetAxis("Horizontal");
            float moveSpeed = Mathf.Abs(horizontalInput);
            // We are going to the right
            if (horizontalInput < 0)
            {
                m_spriteRenderer.flipX = false;
            }
            else if (horizontalInput > 0) // Facing left
            {
                m_spriteRenderer.flipX = true;

            }
             void CheckForPlayerInput()
            {
                if (isDead)
                {
                    return;
                }
                Vector2 playerMovement = new Vector2();
                playerMovement.x = Input.GetAxis("Horizontal");
                playerMovement.y = Input.GetAxis("Vertical");
                if (playerMovement.magnitude != 0.0f)
                {
                    movement.Move(playerMovement);
                    m_animator.SetBool("isMoving", true);
                    float x = Mathf.Abs(playerMovement.x);
                    float y = playerMovement.y;

                    //check for up or down
                    if (y > 0.1f || y < -0.1f)
                    {
                        m_animator.SetFloat("y", y);
                        m_animator.SetFloat("x", 0.0f);

                    }
                    else if (x > 0.0f)
                    {
                        m_animator.SetFloat("y", 0.0f);
                        m_animator.SetFloat("x", x);
                    }

                }
                else { m_animator.SetBool("isMoving", false); }


            }
        }
    }

}
