using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso7_Impresion : MonoBehaviour
{
    public GameObject EstudioImpreso;  // Asignar en inspector
    public GameObject Impresora;       // El cubo que hay que clickear para imprimir
    public float velocidadMovimiento = 1f;  // unidades por segundo

    private bool moviendo = false;
    private bool listoParaMover = false;
    private Vector3 posicionObjetivo;

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.ImprimirEstudio)
        {
            return; // No hacer nada si no estamos en el paso correcto
        }

        if (!listoParaMover)
        {
            // Detectar click en la impresora para empezar la impresión
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == Impresora)
                    {
                        // Preparar para mover el estudio impreso hacia abajo
                        if (EstudioImpreso != null)
                        {
                            posicionObjetivo = EstudioImpreso.transform.position + Vector3.down; // 1 unidad abajo
                            listoParaMover = true;
                            moviendo = true;
                        }
                        else
                        {
                            Debug.LogWarning("EstudioImpreso no está asignado");
                        }
                    }
                }
            }
        }

        if (moviendo)
        {
            EstudioImpreso.transform.position = Vector3.MoveTowards(
                EstudioImpreso.transform.position,
                posicionObjetivo,
                velocidadMovimiento * Time.deltaTime
            );

            if (Vector3.Distance(EstudioImpreso.transform.position, posicionObjetivo) < 0.01f)
            {
                EstudioImpreso.transform.position = posicionObjetivo;
                moviendo = false;

                // Avanzar al siguiente paso
                GameManager3.instancia.AvanzarPaso();
            }
        }
    }
}
