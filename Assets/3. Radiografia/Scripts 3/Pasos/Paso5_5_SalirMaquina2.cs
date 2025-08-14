using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso5_5_SalirMaquina2 : MonoBehaviour
{
    public GameObject Paciente;
    public float velocidadMovimiento = 1f;
    private Vector3 posicionObjetivo;
    public Camera MyCurrentCam;
    private bool moviendo = false;

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.SalirDeMaquina)
        {
            return; // solo funciona en este paso
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Paciente != null)
            {
                // Mover 1 unidad a la derecha
                posicionObjetivo = Paciente.transform.position + Vector3.right*3f;
                moviendo = true;
            }
            else
            {
                Debug.LogWarning("Paciente no está asignado");
            }
        }

        // Mover mientras sea necesario
        if (moviendo)
        {
            Paciente.transform.position = Vector3.MoveTowards(
                Paciente.transform.position,
                posicionObjetivo,
                velocidadMovimiento * Time.deltaTime
            );

            if (Vector3.Distance(Paciente.transform.position, posicionObjetivo) < 0.01f)
            {
                Paciente.transform.position = posicionObjetivo;
                moviendo = false;

                // Avanzar al siguiente paso
                GameManager3.instancia.AvanzarPaso();
            }
        }
    }
}
