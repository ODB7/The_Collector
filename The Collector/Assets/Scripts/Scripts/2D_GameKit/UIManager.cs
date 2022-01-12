using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoDGameKit
{
    // Only Valid UI's for our game
    // Add more if you want
    public enum UINames
    {
        Health, Score, Lives, Message, Enemies 
    }
    public class UIManager : MonoBehaviour
    {
        Dictionary<UINames, UIObject> UIObjectsByName = new Dictionary<UINames, UIObject>();

        public void Subscribe(UINames name, UIObject obj)
        {
            // Look to see if it is already Subscribe
            if (UIObjectsByName.ContainsKey(name))
            {
                if(UIObjectsByName[name] == obj)
                {
                    return;
                }
                else
                {
                    UIObjectsByName[name] = obj;
                    return;
                }
            }
            UIObjectsByName[name] = obj;

        }
        public void ScoreTest()
        {
            UpdateUI(UINames.Score, 10);
        }
        public void MessageTest()
        {
            UpdateUI(UINames.Message, "Jump Sound ");
        }
        // Update Running UI
        public void UpdateUI(UINames name, int number)
        {
            // Find the object by it's name
            if (UIObjectsByName.ContainsKey(name))
            {
                UIObjectsByName[name].UpdateInt(number);
            }
        }
        public void UpdateUI(UINames name, float number)
        {
            // Find the object by it's name
            if (UIObjectsByName.ContainsKey(name))
            {
                UIObjectsByName[name].UpdateFloat(number);
            }
        }
        public void UpdateUI(UINames name, string message)
        {
            // Find the object by it's name
            if (UIObjectsByName.ContainsKey(name))
            {
                UIObjectsByName[name].UpdateString(message);
            }
        }


    }
    
}
