using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [Header("Configuración de Puntos")]
    // Puntos que otorga este enemigo al ser destruido
    public int scoreValue = 100;

    // Necesitamos una referencia a la capa del enemigo para las comprobaciones de seguridad.
    // Esto debería coincidir con la capa "enemy" que mencionaste.
    private int enemyLayer;

    void Start()
    {
        // Obtiene la capa del GameObject al inicio
        enemyLayer = gameObject.layer;

        // Comprobación de seguridad: verifica que la capa sea la correcta
        if (LayerMask.LayerToName(enemyLayer) != "Enemy")
        {
            Debug.LogWarning("El objeto " + gameObject.name + " tiene el script EnemyScore pero NO está en la capa 'enemy'. Por favor, revisa la configuración.");
        }
    }

    // Este método se llama automáticamente justo antes de que el GameObject sea destruido.
    private void OnDestroy()

    {

        Debug.Log("El enemigo " + gameObject.name + " está siendo destruido."); // <-- Añade esta línea

        if (ApplicationIsQuitting()) return;

        if (ScoreManager.Instance != null)
            // **IMPORTANTE:** // 1. Evita dar puntos si la aplicación se está cerrando.
            // 2. Asegúrate de que el ScoreManager existe.
            if (ApplicationIsQuitting()) return;

        if (ScoreManager.Instance != null)
        {
            // Solo si el objeto fue realmente un enemigo que estaba en la capa correcta
            if (LayerMask.LayerToName(enemyLayer) == "enemy")
            {
                ScoreManager.Instance.AddScore(scoreValue);
            }
            // Si quieres que dé puntos aunque no esté en la capa, puedes quitar la línea de arriba y dejar solo:
            // ScoreManager.Instance.AddScore(scoreValue);
        }
        else
        {
            Debug.LogError("No se pudo encontrar el ScoreManager. Asegúrate de que está en la escena.");
        }

        ScoreManager.Instance.AddScore(scoreValue);
    }

    // Para evitar errores cuando el juego se cierra
    private bool ApplicationIsQuitting()
    {
        // Unity a veces llama a OnDestroy cuando el motor se detiene.
        // La lógica de puntuación solo debe ejecutarse si el objeto se destruye durante el juego.
        return !Application.isPlaying;
    }



}