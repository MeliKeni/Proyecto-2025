using UnityEngine;

public class AbrirCalendario : MonoBehaviour
{
    public GameObject calendario;
    private UIUsuarios logeoUI;

    void Start()
    {
        calendario.SetActive(false);

        // Buscar el script UIUsuarios que viene de la escena anterior

        // Si existe y está logeado, mostramos el calendario
        if (logeoUI != null && logeoUI.logeado)
        {
            calendario.SetActive(true);
        }
    }

    void Update()
    {
        // Por si la escena carga antes de detectar el login
        if (logeoUI.logeado == true)
        { calendario.SetActive(true);
        }
    }
}
