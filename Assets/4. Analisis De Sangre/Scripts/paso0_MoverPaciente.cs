using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso0_MoverPaciente : MonoBehaviour
{
    GameObject pacienteSeleccionado;
    public float velocidad = 3f;
    public Camera MyCurrentCam;
    public uIManagerCuatro uiManager;

    public Animator anim;
    Vector3 destino = Vector3.zero;

    public GameObject paciente1;
    public GameObject paciente2;
void Start(){
                anim.SetBool("Sentarse", false);
                
                    anim.SetBool("Caminar", false);
                paciente1.SetActive(false);
                paciente2.SetActive(true);
}
    void Update()
    {
        if(paciente1.activeSelf){
            anim.SetBool("Sentarse", true);
        }
        if (gameManagerCuatro.instancia == null ||
            gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PacienteSilla)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Paciente"))
                {
                    pacienteSeleccionado = hit.collider.gameObject;
                    uiManager.avanzarTag = true;
                }
                else if (hit.collider.CompareTag("Silla") && pacienteSeleccionado != null)
                {
                    destino = hit.collider.transform.position;
                    uiManager.avanzarTag = true;
                    anim.SetBool("Caminar", true); //* no funciona
                StartCoroutine(EsperarYAvanzar());

               
                }
            }
        }

          IEnumerator EsperarYAvanzar()
    {
        yield return new WaitForSeconds(3f);

        paciente1.SetActive(true);
        paciente2.SetActive(false);

        anim.SetBool("Caminar", false);
        anim.SetBool("Sentarse", true);
        yield return new WaitForSeconds(3f);

        gameManagerCuatro.instancia.AvanzarPaso();
    }
    }
}
