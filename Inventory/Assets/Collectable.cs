using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public string itemType;
    void OnCollisionEnter(Collision collision)
    {
        // If the item we have collided with is the player
        // Destory this item
        if (collision.gameObject.CompareTag("Player"))
        {

            Inventory.GetInventory.AddToInventory(itemType);
            Destroy(gameObject);
        }
    }
}
