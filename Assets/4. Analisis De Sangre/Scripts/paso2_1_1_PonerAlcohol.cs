using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso2_1_1_PonerAlcohol : MonoBehaviour
{
    public Camera MyCurrentCam;
    GameObject algodonSeleccionado;

    public uIManagerCuatro uiManager;

    void Start()
    {
        
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
                    //animacion
                    gameManagerCuatro.instancia.AvanzarPaso();


    
    uiManager.avanzarTag = true;
    
                }
            }
        }
    }
}
