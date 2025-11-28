using UnityEngine;
using UnityEngine.UI;

public class DetectMouseMovement : MonoBehaviour
{
    Vector3 ultimaCoordenada = Vector3.zero;
    float timer = 0f;
    float tiempoNecesario = 2f;

    public Slider barraProgresoMovimiento;
    public uIManagerCuatro uiManager;

    void Update()
    {
        // Si no es el paso correcto → resetear barra y no hacer nada más
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PonerAlgodon1)
        {
            ResetearBarra();

            barraProgresoMovimiento.gameObject.SetActive(false);
            return;
        }
        else
        {
            barraProgresoMovimiento.gameObject.SetActive(true);
        }

        // Si no estás haciendo click izquierdo → resetear
        if (!Input.GetMouseButton(0))
        {
            ResetearTodo();
            return;
        }

        // Primera vez: guardar coordenada
        if (ultimaCoordenada == Vector3.zero)
        {
            ultimaCoordenada = Input.mousePosition;
            return;
        }

        Vector3 mouseDelta = Input.mousePosition - ultimaCoordenada;

        // Si hay movimiento
        if (mouseDelta != Vector3.zero)
        {
            timer += Time.deltaTime;

            // Actualizar barra
            barraProgresoMovimiento.value = timer / tiempoNecesario;

            // Cuando pasa el tiempo → avanzar paso
            if (timer >= tiempoNecesario)
            {
                gameManagerCuatro.instancia.AvanzarPaso();
                ResetearTodo();
            }
        }
        else
        {
            // Si el mouse no se mueve → resetear
            ResetearTodo();
        }

        ultimaCoordenada = Input.mousePosition;
    }

    void ResetearTodo()
    {
        timer = 0f;
        ultimaCoordenada = Vector3.zero;
        barraProgresoMovimiento.value = 0f;
    }

    void ResetearBarra()
    {
        barraProgresoMovimiento.value = 0f;
    }
}
