using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso0_MoverPaciente : MonoBehaviour
{
    GameObject pacienteSeleccionado;
    public float velocidad = 3f;
    Vector3 destino;

    void Update()
    {
        if (GameManager3.instancia == null)
        {
            Debug.LogWarning("GameManager3 instancia es null");
            return;
        }

        if (!GameManager3.instancia.EsPaso(PasoRadiografia.MoverPaciente))
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Clic en: " + hit.collider.name);

                if (hit.collider.CompareTag("Paciente"))
                {
                    pacienteSeleccionado = hit.collider.gameObject;
                    destino = pacienteSeleccionado.transform.position;
                    Debug.Log("Paciente seleccionado: " + pacienteSeleccionado.name);
                }
                else if (hit.collider.CompareTag("Silla") && pacienteSeleccionado != null)
                {
                    destino = hit.collider.transform.position;
                    Debug.Log("Destino asignado a silla: " + destino);
                }
            }
        }

        if (pacienteSeleccionado != null)
        {
            pacienteSeleccionado.transform.position = Vector3.MoveTowards(
                pacienteSeleccionado.transform.position,
                destino,
                velocidad * Time.deltaTime
            );

            float distancia = Vector3.Distance(pacienteSeleccionado.transform.position, destino);
            Debug.Log("Distancia al destino: " + distancia);

            if (distancia < 0.01f)
            {
                pacienteSeleccionado = null;
                Debug.Log("Paciente llegó al destino. Avanzando paso.");
                GameManager3.instancia.AvanzarPaso();
            }
        }
    }
}
