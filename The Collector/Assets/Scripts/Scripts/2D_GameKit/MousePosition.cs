using UnityEngine;
namespace TwoDGameKit
{
    public class MousePosition : MonoBehaviour
    {
       public static Vector2 mouseWorldPosition { get; private set; }
        // Update is called once per frame
        void Update()
        {
            mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
