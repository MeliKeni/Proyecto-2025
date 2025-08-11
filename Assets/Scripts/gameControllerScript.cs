using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControllerScript : MonoBehaviour
{

    GameObject pacienteSeleccionado;
    public float velocidad = 3f;

    Vector3 destino;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                    destino = pacienteSeleccionado.transform.position; // se queda quieto hasta elegir silla
                }
                // Si clickeaste la silla y hay paciente seleccionado
                else if (hit.collider.CompareTag("Silla") && pacienteSeleccionado != null)
                {
                    destino = hit.collider.transform.position;
                }
            }
        }

        // Mover paciente hacia el destino
        if (pacienteSeleccionado != null)
        {
            pacienteSeleccionado.transform.position = Vector3.MoveTowards(
                pacienteSeleccionado.transform.position,
                destino,
                velocidad * Time.deltaTime
            );
        }

    }
}
