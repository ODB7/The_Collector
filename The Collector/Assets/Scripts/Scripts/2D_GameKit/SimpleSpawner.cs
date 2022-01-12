using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TwoDGameKit
{
    public class SimpleSpawner : MonoBehaviour
    {
        // Spawned Objects
        [SerializeField] private GameObject[] spawnedObjects;

        [SerializeField, Range(0, 5),
            Tooltip("Time before the timer will start")]
        protected float startDelay;
        [SerializeField, Range(0, 5),
            Tooltip("Time between each spawn")]
        protected float interval;

        public bool doBreak = false;

        // Start is called before the first frame update
        void Start()
        {
            Initialize();
        }

        protected void Initialize()
        {
            StartCoroutine("ListenForSpawn");

        }

        protected virtual IEnumerator ListenForSpawn()
        {
            while (true)
            {
                if (doBreak)
                {
                    break;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Spawning");
                    SpawnObject();
                }
                yield return null;

            }

            yield return null;
        }

        protected virtual void SpawnObject()
        {

            Instantiate(spawnedObjects[0], MousePosition.mouseWorldPosition,
                spawnedObjects[0].transform.rotation);
        }

    }
}