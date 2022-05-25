using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory GetInventory => instance;
    private int coins = 0;
    private int bomb = 0;
    private int misc = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddToInventory(string item)
    {
        if(item == "coin")
        {
            coins += 1;
            Debug.Log("You have" + coins + " coins");
        }

        if (item == "bomb")
        {
            bomb += 1;
            Debug.Log("You have" + bomb + " bomb");
        }
        else
        {
            misc += 1;
            Debug.Log("You have" + misc + " misc");
        }
    }
}
