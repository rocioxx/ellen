using UnityEngine;
using TMPro; // Asegúrate de tener esta librería

public class ScoreTextLinker : MonoBehaviour
{
    private void Start()
    {
        // 1. Obtener la referencia al componente de texto en este GameObject.
        TextMeshProUGUI currentTextComponent = GetComponent<TextMeshProUGUI>();

        if (currentTextComponent == null)
        {
            Debug.LogError("ScoreTextLinker está en un objeto sin componente TextMeshProUGUI. Por favor, revísalo.");
            return;
        }

        // 2. Comprobar si el ScoreManager persistente existe.
        if (ScoreManager.Instance != null)
        {
            // 3. ¡El enlace! Asigna este nuevo componente de texto al ScoreManager.
            ScoreManager.Instance.scoreText = currentTextComponent;

            // Opcional: Asegúrate de que el texto muestra la puntuación actual 
            // inmediatamente después de cargar la escena.
            ScoreManager.Instance.UpdateScoreText();
        }
        else
        {
            Debug.LogError("No se encontró ScoreManager.Instance en la escena.");
        }
    }
}