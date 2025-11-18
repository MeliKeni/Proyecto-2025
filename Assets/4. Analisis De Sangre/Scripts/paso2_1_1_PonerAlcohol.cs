using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso2_1_1_PonerAlcohol : MonoBehaviour
{
    public Camera MyCurrentCam;
    GameObject algodonSeleccionado;
    public Animator anim;

    public GameObject algodon1;
    public GameObject algodon2;
    public Material nuevoMaterial;

    public uIManagerCuatro uiManager;

    void Start()
    {
        anim.SetBool("Mojar", false);
        anim.SetBool("Frenar", false);
        algodon1.SetActive(true);
        algodon2.SetActive(false);
        
    }

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PonerAlcohol)
            return;

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
                    StartCoroutine(MojarAlgodon());
                    uiManager.avanzarTag = true;
                }
            }
        }
    }

    IEnumerator MojarAlgodon()
    {
        anim.SetBool("Mojar", true);

        // Esperar la duración REAL de la animación
        yield return new WaitForSeconds(3f);
        Debug.Log("panchito");

        anim.SetBool("Mojar", false);
        anim.SetBool("Frenar", true);
algodon1.SetActive(false);
algodon2.SetActive(true);
    gameManagerCuatro.instancia.AvanzarPaso();
    }
}
