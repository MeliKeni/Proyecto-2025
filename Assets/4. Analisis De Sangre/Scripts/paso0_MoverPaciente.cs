using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso0_MoverPaciente : MonoBehaviour
{
    GameObject pacienteSeleccionado;
    public float velocidad = 3f;
    public Camera MyCurrentCam;
    public Animator anim;
    bool listoparaanim=false;

    Vector3 destino = Vector3.zero;

    void Start()
    {

        anim.SetBool("Sentarse", false);
    }


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
                //Debug.Log(hit.collider.tag);

                if (hit.collider.CompareTag("Paciente"))
                {
                    pacienteSeleccionado = hit.collider.gameObject;
                     anim = pacienteSeleccionado.GetComponent<Animator>();
                }
                else if (hit.collider.CompareTag("Silla") && pacienteSeleccionado != null)
                {
                    destino = hit.collider.transform.position;
                    listoparaanim = true;


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

            if (listoparaanim == true)
            {
                anim.SetBool("Sentarse", true);
                gameManagerCuatro.instancia.AvanzarPaso();
                pacienteSeleccionado = null;
                destino = Vector3.zero;
            }
        }

    if (pacienteSeleccionado != null && destino != Vector3.zero)
{
    if (Vector3.Distance(pacienteSeleccionado.transform.position, destino) < 0.05f)
    {
        if (listoparaanim)
        {
            anim.SetBool("Sentarse", true);
            gameManagerCuatro.instancia.AvanzarPaso();

            // ✅ Reset
            listoparaanim = false;
            pacienteSeleccionado = null;
            destino = Vector3.zero;
        }
    }
}
    }
}

