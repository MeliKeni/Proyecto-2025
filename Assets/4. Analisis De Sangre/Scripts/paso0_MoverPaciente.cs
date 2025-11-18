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
void Start(){
                anim.SetBool("Sentarse", false);
                
                paciente1.SetActive(true);
}
    void Update()
    {
       
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
                    anim.SetBool("Sentarse", true); 
                StartCoroutine(EsperarYAvanzar());
                }
                       }
        }

          IEnumerator EsperarYAvanzar()
    {
        anim.SetBool("Sentarse", true);
        yield return new WaitForSeconds(3f);

        gameManagerCuatro.instancia.AvanzarPaso();
    }
    }
}
