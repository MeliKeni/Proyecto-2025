using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso4_SacarSangre : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject jeringa;
    public Camera MyCurrentCam;

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.SacarSangre)
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
                if (h.collider != null && h.collider.gameObject == jeringa)
                {
                    gameManagerCuatro.instancia.AvanzarPaso();
                }
            }
        }
    }
}
