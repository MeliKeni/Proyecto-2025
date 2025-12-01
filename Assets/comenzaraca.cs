using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comenzaraca : MonoBehaviour
{
    void Start()
    {
        // Obtener el nombre de la escena actual
        string escenaActual = SceneManager.GetActiveScene().name;

        // Verificar si es la escena deseada
        if (escenaActual == "Escena 4 Analisis de sangre 2")
        {
            Debug.Log("Ya estoy en la escena correcta, no cambio.");
            // No haces nada → se queda en esa escena
        }
        else
        {
            Debug.Log("No estoy en la escena correcta, podés cargarla si querés.");
            // Si quisieras forzarla, sería:
            // SceneManager.LoadScene("Escena 4 Analisis de sangre 2");
        }
    }
}
