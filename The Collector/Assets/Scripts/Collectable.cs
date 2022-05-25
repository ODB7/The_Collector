using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemType;
    private void OnCollisionEnter2D(Collision2D collision)
    {
   
        if (collision.gameObject.CompareTag("Player"))
        {
            Inventory.GetInventory.AddToInventory(itemType);
            Destroy(gameObject);
        }
        Debug.Log("Collision");
    }
}
