using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso2_1_4TirarBasura : MonoBehaviour
{
    public Camera MyCurrentCam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.TirarAlgodon)
        {
            return;
        }

        // Detectar click con el mouse
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider.CompareTag("Tacho"))
                {
                    gameManagerCuatro.instancia.AvanzarPaso();
                }
            }
        }
    }
}
