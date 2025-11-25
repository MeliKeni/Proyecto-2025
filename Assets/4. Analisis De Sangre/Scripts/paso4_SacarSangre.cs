using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso4_SacarSangre : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject jeringa;
    public Camera MyCurrentCam;
    public Animator anim;

    public uIManagerCuatro uiManager;
    void Start()
    {
        anim.SetBool("SacarSangre", false);
    }
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
                if (h.collider.CompareTag("Jeringa"))
                {
                    anim.SetBool("SacarSangre", true);
                    uiManager.avanzarTag = true;
                    gameManagerCuatro.instancia.AvanzarPaso();
                }
            }
        }
    }
}
