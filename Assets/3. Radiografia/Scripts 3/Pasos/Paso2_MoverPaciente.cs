using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso2_MoverPaciente : MonoBehaviour
{
    GameObject pacienteSeleccionado;
    public float velocidad = 3f;
    public Camera MyCurrentCam;
    public GameObject target;

    Vector3 destino = Vector3.zero; // Inicializar en cero para controlar si está seteado
    bool esperando = false; // Para no iniciar corrutina múltiples veces

    void Update()
    {
        // Solo funciona si estamos en el paso PacienteMaquina
        if (GameManager3.instancia.pasoActual != PasoRadiografia.PacienteMaquina)
        {
            return; // anulamos todo si no estamos en el paso que hay que estar
        }

        // Detectar click con Raycast
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Si clickeaste al paciente
                if (hit.collider.CompareTag("Paciente"))
                {
                    pacienteSeleccionado = hit.collider.gameObject;
                }
                // Si clickeaste la silla y hay paciente seleccionado
                else if (hit.collider.CompareTag("Maquina") && pacienteSeleccionado != null)
                {
                    destino = target.transform.position;
                }
            }
        }

        // Mover paciente hacia el destino solo si destino fue seteado (distinto de cero)
        if (pacienteSeleccionado != null && destino != Vector3.zero && !esperando)
        {
            pacienteSeleccionado.transform.position = Vector3.MoveTowards(
                pacienteSeleccionado.transform.position,
                destino,
                velocidad * Time.deltaTime
            );

            // Si llegó cerca al destino (distancia menor a 0.1)
            if (Vector3.Distance(pacienteSeleccionado.transform.position, destino) < 0.1f)
            {
                esperando = true; // Para evitar entrar otra vez mientras esperamos
                StartCoroutine(EsperarYAvanzar());
            }
        }
    }

    IEnumerator EsperarYAvanzar()
    {
        yield return new WaitForSeconds(0.6f);  // Espera 1 segundo
        GameManager3.instancia.AvanzarPaso();
        pacienteSeleccionado = null;   // Para que no siga moviéndose ni avanzando pasos
        destino = Vector3.zero;        // Reseteamos el destino para esperar la próxima acción
        esperando = false;             // Ya no estamos esperando
    }
}
