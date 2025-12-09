using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        // Obtiene el componente de texto.
        scoreText = GetComponent<TextMeshProUGUI>();

        // Muestra la puntuación que ya trae el Manager al inicio de la escena.
        if (ScoreManager.instance != null)
        {
            UpdateScore(ScoreManager.instance.currentScore);
        }
    }

    void OnEnable()
    {
        // Se suscribe al evento: cuando el Manager añade puntos, llama a UpdateScore.
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.onScoreChange += UpdateScore;
        }
    }

    void OnDisable()
    {
        // Desuscripción obligatoria para evitar errores.
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.onScoreChange -= UpdateScore;
        }
    }

    // Este método actualiza el texto en pantalla.
    void UpdateScore(int newScore)
    {
        scoreText.text = "Puntuación: " + newScore;
    }
}