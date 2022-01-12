using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace TwoDGameKit
{
    public class MessageUIObject : UIObject
    {
        public TextMeshProUGUI messageText;
        private float timer = 0.0f;
        public float timerLength = 2.0f;
        // Start is called before the first frame update
        void Start()
        {
            var manager = GameObject.FindWithTag("Manager");
            manager.GetComponent<UIManager>().Subscribe(UINames.Message, this);
        }

        // Update is called once per frame
        void Update()
        {
            // Check if our TMPro is enabled
            if (messageText.enabled)
            {
                timer -= Time.deltaTime;
                if(timer <= 0.0f)
                {
                    messageText.enabled = false;
                }
            }
        }
        public override void UpdateString(string message)
        {
            messageText.text = message;
            UpdateUI();
        }
        protected override void UpdateUI()
        {
            messageText.enabled = true;
            timer = timerLength;

        }

    }
}
