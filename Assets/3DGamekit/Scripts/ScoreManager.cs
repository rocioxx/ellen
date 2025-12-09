using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // 1. Singleton: Permite acceder a esta instancia desde cualquier otro script.
    public static ScoreManager instance;

    // 2. Almacena la puntuación total.
    public int currentScore = 0;

    // 3. Evento: Notifica a la UI cuando la puntuación cambia.
    public delegate void OnScoreChange(int newScore);
    public event OnScoreChange onScoreChange;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            // ¡CRUCIAL! Mantiene este objeto vivo al cargar nuevas escenas.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe, destruye esta copia.
            Destroy(gameObject);
        }
    }

    // Método público que los bichos/cofres llamarán para añadir puntos.
    public void AddScore(int amount)
    {
        currentScore += amount;

        // Notifica a la UI que debe actualizarse.
        if (onScoreChange != null)
        {
            onScoreChange.Invoke(currentScore);
        }
        Debug.Log("Puntuación acumulada: " + currentScore);
    }
}