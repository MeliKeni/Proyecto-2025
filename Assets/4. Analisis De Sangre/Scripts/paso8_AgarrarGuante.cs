using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso8_AgarrarGuante : MonoBehaviour
{
    public Camera MyCurrentCam;
    public bool cursorGuante = false;

    void Update()
    {
        if (gameManagerCuatro.instancia?.pasoActual != PasoAnalisisDeSangre.AgarrarGuante)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.CompareTag("Guante"))
                {
                    cursorGuante = true;
                    gameManagerCuatro.instancia.AvanzarPaso();
                }
            }
           
        }

         if (Input.GetKeyDown(KeyCode.F))
        {
            gameManagerCuatro.instancia.AvanzarPaso();
        }
    }
}

