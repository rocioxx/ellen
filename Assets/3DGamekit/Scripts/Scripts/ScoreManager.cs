using UnityEngine;
using TMPro; // Asegúrate de tener esta librería si usas TextMeshPro
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Singleton pattern: acceso fácil desde cualquier otro script
    public static ScoreManager Instance;

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText; // Referencia al componente de texto de la UI

    private int currentScore = 0;


    private void Awake()
    {
        // Implementación del Singleton
        if (Instance == null)
        {
            Instance = this;
            // Opcional: para que persista entre escenas
            DontDestroyOnLoad(gameObject);
          
        }
        else
        {
            Destroy(gameObject);
        }

        // Inicializa la UI con la puntuación inicial
        UpdateScoreText();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateScoreText();
    }
    /// <summary>
    /// Añade puntos a la puntuación actual.
    /// </summary>
    /// <param name="pointsToAdd">La cantidad de puntos a sumar.</param>
    public void AddScore(int pointsToAdd)
    {
        currentScore += pointsToAdd;
        UpdateScoreText();
        Debug.Log("Puntuación actual: " + currentScore);
    }

    // Actualiza el texto de la UI
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            // Puedes personalizar el formato del texto aquí
            scoreText.text = "PUNTOS: " + currentScore.ToString();
        }
    }

    // Opcional: Devuelve la puntuación actual
    public int GetCurrentScore()
    {
        return currentScore;
    }
}