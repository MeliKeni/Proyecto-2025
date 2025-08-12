using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso2_MoverPaciente : MonoBehaviour
{
    GameObject pacienteSeleccionado;
    public float velocidad = 3f;

    Vector3 destino = Vector3.zero; // Inicializo en cero para controlar si está seteado

    // Update is called once per frame
    void Update()
    {
        // Solo funciona si estamos en el paso PacienteMaquina
        if (GameManager3.instancia.pasoActual != PasoRadiografia.PacienteMaquina)
        {
            return; // No hacemos nada si no es el paso correcto
        }

        // Detectar click con Raycast
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Si clickeaste al paciente
                if (hit.collider.CompareTag("Paciente"))
                {
                    pacienteSeleccionado = hit.collider.gameObject;
                    // No actualizamos destino acá para evitar que pase el paso al instante
                }
                // Si clickeaste la silla y hay paciente seleccionado
                else if (hit.collider.CompareTag("Silla") && pacienteSeleccionado != null)
                {
                    destino = hit.collider.transform.position;
                }
            }
        }

        // Mover paciente hacia el destino solo si destino fue seteado (distinto de cero)
        if (pacienteSeleccionado != null && destino != Vector3.zero)
        {
            pacienteSeleccionado.transform.position = Vector3.MoveTowards(
                pacienteSeleccionado.transform.position,
                destino,
                velocidad * Time.deltaTime
            );

            // Si llegó cerca al destino (distancia menor a 0.1)
            if (Vector3.Distance(pacienteSeleccionado.transform.position, destino) < 0.1f)
            {
                GameManager3.instancia.AvanzarPaso();
                pacienteSeleccionado = null;   // Para que no siga moviéndose ni avanzando pasos
                destino = Vector3.zero;        // Reseteamos el destino para esperar la próxima acción
            }
        }
    }
}
