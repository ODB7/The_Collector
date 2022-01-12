using UnityEngine;
namespace TwoDGameKit
{
    public class EnemyCollision : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("I am working");
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var i = 0;
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.SendMessage("TakeDamage", 10, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
