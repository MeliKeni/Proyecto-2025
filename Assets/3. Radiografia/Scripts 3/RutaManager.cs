using UnityEngine;

public class RutaManager : MonoBehaviour
{
    public int puntoActual = 0;        // El índice del siguiente punto que hay que tocar
    public LineRenderer linea;         // Arrastrar aquí el LineRenderer desde la escena

    void Update()
    {
        // Mientras mantengas presionado el mouse, dibuja la línea
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f; // Distancia desde la cámara
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            // Solo agregamos el punto si es distinto del anterior para no saturar
            if (linea.positionCount == 0 || linea.GetPosition(linea.positionCount - 1) != worldPos)
            {
                linea.positionCount++;
                linea.SetPosition(linea.positionCount - 1, worldPos);
            }
        }

        // Si soltás el mouse, reinicia la línea
        if (Input.GetMouseButtonUp(0))
        {
            linea.positionCount = 0;
        }
    }

    // Este método lo llaman los puntos
    public void PuntoTocado(int orden)
    {
        if (orden == puntoActual)
        {
            Debug.Log("Correcto: " + orden);
            puntoActual++;

            // Si completaste todos los puntos
            if (puntoActual >= TotalDePuntos())
            {
                Debug.Log("Recorrido completo!");
                // Podés hacer algo acá, por ejemplo bloquear el mouse o mostrar mensaje
            }
        }
        else
        {
            Debug.Log("Incorrecto, reiniciando...");
            puntoActual = 0;
            linea.positionCount = 0; // Reinicia la línea
        }
    }

    int TotalDePuntos()
    {
        return FindObjectsOfType<NewBehaviourScript>().Length;
    }
}
