using UnityEngine;
using TMPro; // Necesario para TextMeshPro

public class WinScreenManager : MonoBehaviour
{
    [Header("Referencias de UI")]
    // Arrastra el componente de texto de puntuación final aquí.
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        // 1. Verificar si el ScoreManager persistente existe.
        if (ScoreManager.Instance != null)
        {
            // 2. Obtener la puntuación final acumulada.
            int finalScore = ScoreManager.Instance.GetCurrentScore();

            // 3. Actualizar el texto del Canvas.
            if (finalScoreText != null)
            {
                finalScoreText.text = $"PUNTUACIÓN FINAL: {finalScore}";
            }
            else
            {
                Debug.LogError("La referencia 'finalScoreText' en el WinScreenManager está vacía. ¡Arrastra el componente de texto!");
            }

            // Opcional: Destruir el ScoreManager después de usar la puntuación
            // Solo haz esto si el ScoreManager ya no será necesario después de la pantalla de victoria
            // Destroy(ScoreManager.Instance.gameObject);
        }
        else
        {
            // En caso de que se cargue la escena de victoria directamente sin jugar
            Debug.LogWarning("ScoreManager no encontrado. Estableciendo puntuación a 0.");
            if (finalScoreText != null)
            {
                finalScoreText.text = "PUNTUACIÓN FINAL: 0";
            }
        }
    }
}