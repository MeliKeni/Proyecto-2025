using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso1_PuertaArmario : MonoBehaviour
{
    public GameObject puerta;
    public Camera MyCurrentCam;
    public bool pasoTerminado1=false;

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
                if (hit.collider != null && hit.collider.gameObject == puerta)
                {
                    // Al hacer clic en la puerta, avanzar de paso
                    pasoTerminado1= true;
                    gameManagerCuatro.instancia.AvanzarPaso();

                }
            }
        }
    }
}



