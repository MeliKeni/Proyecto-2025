using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso7_PonerCurita : MonoBehaviour
{
        public Camera MyCurrentCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PonerCurita)
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
                if (h.collider.CompareTag("Brazo"))
                {
                    gameManagerCuatro.instancia.AvanzarPaso();
                }
            }
        }
    }
}
