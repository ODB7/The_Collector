using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory GetInventory => instance;
    private int KeyCard = 0;
    private int Coins = 0;
    private int Shield = 0;
    private int Hammer = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddToInventory(string item)
    {
        if(item == "KeyCard")
        {
            KeyCard += 1;
            Debug.Log("You have" + KeyCard + " Key Card");
        }

        if (item == "Hammer")
        {
            Hammer += 1;
            Debug.Log("You are worthy to hold Thor's Hammer!");
        }

        if (item == "Coins")
        {
            Coins += 1;
            Debug.Log("You have" + Coins + " coins");
        }
        if (item == "Shield")
        {
            Shield += 1;
            Debug.Log("You have found Cap's Shield!");
        }
    }
}
