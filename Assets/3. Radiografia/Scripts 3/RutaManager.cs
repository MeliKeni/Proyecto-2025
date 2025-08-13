using UnityEngine;

public class RutaManager : MonoBehaviour
{
    public int puntoActual = 0; // Qué punto sigue en la secuencia
    public GameObject canvas;
    public void Start()
    {
        canvas.SetActive(false);
    }

    public void PuntoTocado(int orden)
    {
        // Solo avanza si el punto es el correcto
        if (orden == puntoActual)
        {
            Debug.Log("Correcto: " + orden);
            puntoActual++;

            // Completó todos los puntos
            if (puntoActual >= TotalDePuntos())
            {
                Debug.Log("Recorrido completo!");
                GameManager3.instancia.AvanzarPaso();
                canvas.SetActive(false);


            }
        }
        else
        {
            Debug.Log("Incorrecto, reiniciando...");
            puntoActual = 0;
        }
    }

    int TotalDePuntos()
    {
        return FindObjectsOfType<Punto>().Length;
    }
    public void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.GestoComputadora)
        {
            return;
        }
        else
        {
            canvas.SetActive(true);
        }
    }
}
