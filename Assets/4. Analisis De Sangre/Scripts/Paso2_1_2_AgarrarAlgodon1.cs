using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso2_1_2_AgarrarAlgodon1 : MonoBehaviour
{
    public Camera MyCurrentCam;
    public bool cambiarCamara=false;

    public uIManagerCuatro uiManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.AgarrarAlgodon1)
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
                    gameManagerCuatro.instancia.AvanzarPaso();
                    cambiarCamara = true;



    uiManager.avanzarTag = true;

                }
            }
        }
    }
}
