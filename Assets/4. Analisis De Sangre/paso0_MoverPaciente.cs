using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso0_MoverPaciente : MonoBehaviour
{
    GameObject pacienteSeleccionado;
    public float velocidad = 3f;
    public Camera MyCurrentCam;

    Vector3 destino = Vector3.zero;

    void Update()
    {
        // Si el GameManager no existe o no estamos en el paso correcto, no hacer nada
        if (gameManagerCuatro.instancia == null || gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PacienteSilla)
        {
            return;
        }

        // Detectar click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Paciente"))
                {
                    pacienteSeleccionado = hit.collider.gameObject;
                }
                else if (hit.collider.CompareTag("Maquina") && pacienteSeleccionado != null)
                {
                    destino = hit.collider.transform.position;
                }
            }
        }

        // Mover paciente hacia el destino
        if (pacienteSeleccionado != null && destino != Vector3.zero)
        {
            pacienteSeleccionado.transform.position = Vector3.MoveTowards(
                pacienteSeleccionado.transform.position,
                destino,
                velocidad * Time.deltaTime
            );

            if (Vector3.Distance(pacienteSeleccionado.transform.position, destino) < 0.1f)
            {
                gameManagerCuatro.instancia.AvanzarPaso();
                pacienteSeleccionado = null;
                destino = Vector3.zero;
            }
        }
    }
}