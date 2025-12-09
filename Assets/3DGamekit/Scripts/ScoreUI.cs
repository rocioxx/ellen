using UnityEngine;
using TMPro;

namespace Gamekit3D
{
    public class ScoreUI : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;

        void Start()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
            if (ScoreManager.instance != null)
            {
                UpdateScore(ScoreManager.instance.currentScore);
            }
        }

        void OnEnable()
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.onScoreChange += UpdateScore;
            }
        }

        void OnDisable()
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.onScoreChange -= UpdateScore;
            }
        }

        void UpdateScore(int newScore)
        {
            if (scoreText != null)
                scoreText.text = "Puntuación: " + newScore;
        }
    }
}