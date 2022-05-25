using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    public string  SceneToLaod;
    [SerializeField] private string leavingLocation;
    [SerializeField] private string arrivingLocation;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            other.gameObject.GetComponent<TwoDGameKit.PlayerController>().UpdateLeavingLocation(leavingLocation, arrivingLocation);
            SceneManager.LoadScene(SceneToLaod);
        }
      
    }
}
