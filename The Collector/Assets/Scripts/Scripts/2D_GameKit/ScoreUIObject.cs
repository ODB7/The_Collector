using TMPro;
using UnityEngine;
namespace TwoDGameKit
{
    // Notice here that instead of : Monobehaviour we are inheriting from UIObject
    // UIObjects are MonoBehavior so we call still
    public class ScoreUIObject : UIObject
    {
        [SerializeField] private int currentScore = 0;
        [SerializeField] private TextMeshProUGUI ScoreText;
        private void Start()
        {
            var manager = GameObject.FindWithTag("Manager");
            manager.GetComponent<UIManager>().Subscribe(UINames.Score, this);
        }
        public override void UpdateInt(int number)
        {
            // For Score we are expecting to add the number to our score and than update UI
            currentScore += number;
            UpdateUI();
        }

        protected override void UpdateUI()
        {
            // Take our Score Text object, and change the text properry to be the current score
            // Our current score is a number so we need to convert it to a string
            ScoreText.text = currentScore.ToString();
        }
    }
}
