using UnityEngine;

public class DetectMouseMovement : MonoBehaviour
{
    Vector3 ultimaCoordenada = Vector3.zero;
    float timer = 0f;
    float tiempoNecesario = 2f;

    public uIManagerCuatro uiManager;

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PonerAlgodon1)
        {
            return;
        }
        //si no estas haciendo click izquierdo no te cuenta el movimiento 
        if (!Input.GetMouseButton(0))
        {
            timer = 0f;
            ultimaCoordenada = Vector3.zero;
            return;
        }
        if (ultimaCoordenada == Vector3.zero)
        {
            ultimaCoordenada = Input.mousePosition;
            return;
        }

        Vector3 mouseDelta = Input.mousePosition - ultimaCoordenada;

        // Detecta el movimiento
        if (mouseDelta != Vector3.zero)
        {
            timer += Time.deltaTime;

            if (timer >= tiempoNecesario)
            {
                gameManagerCuatro.instancia.AvanzarPaso();

            }
        }
        else
        {
            // Si no hay movimiento se resetea
            timer = 0f;
        }

        // Guardar última posición del mouse
        ultimaCoordenada = Input.mousePosition;
    }
}
