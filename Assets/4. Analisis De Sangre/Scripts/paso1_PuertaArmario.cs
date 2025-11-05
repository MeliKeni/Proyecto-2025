using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso1_PuertaArmario : MonoBehaviour
{
    public Camera MyCurrentCam;
    public uIManagerCuatro uiManager;
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.AbrirArmario)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Armario"))
                {
                    // Al hacer clic en la puerta, avanzar de paso
                    gameManagerCuatro.instancia.TagDeseada = "Guante";

                  uiManager.avanzarTag = true;
                    gameManagerCuatro.instancia.AvanzarPaso();

                }
            }
        }
    }
}



