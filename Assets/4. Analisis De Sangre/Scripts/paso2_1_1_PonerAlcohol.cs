using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso2_1_1_PonerAlcohol : MonoBehaviour
{
    public Camera MyCurrentCam;
    GameObject algodonSeleccionado;
    public Animator anim;
 

    public uIManagerCuatro uiManager;

    void Start()
    {
        anim.SetBool("Mojar", false);
        anim.SetBool("Frenar", false);

    }

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PonerAlcohol)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Algodon"))
                {
                    algodonSeleccionado = hit.collider.gameObject;


    
    uiManager.avanzarTag = true;
                }
                else if (hit.collider.CompareTag("Botella") && algodonSeleccionado != null)
                {
                    anim.SetBool("Mojar", true);
                    StartCoroutine(Esperar());

                    anim.SetBool("Mojar", false);
                    anim.SetBool("Frenar", true);

                    //animacion
                    gameManagerCuatro.instancia.AvanzarPaso();


    
    uiManager.avanzarTag = true;
    
                }
            }
        }
    }
    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2.31f);

    }

}
