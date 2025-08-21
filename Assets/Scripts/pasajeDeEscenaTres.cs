using UnityEngine;
using UnityEngine.SceneManagement;

public class pasajeDeEscenaTres : MonoBehaviour
{
    void Start()
    {
        // Me aseguro de enganchar el evento cuando arranca este script
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // Me desengancho para no duplicar suscripciones
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnBotonClick()
    {
        SceneManager.LoadScene("Escena 3 Radiografia");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Escena 3 Radiografia")
        {
            // Solo si tus managers tienen Reset()
            if (GameManager3.instancia != null)
                GameManager3.instancia.ResetGame();

            if (UIManager3.instancia != null)
                UIManager3.instancia.ResetUI();
        }
    }
}
