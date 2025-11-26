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
        jeringa.SetActive(false); 
        anim.SetBool("SacarSangre", false);
    }
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.SacarSangre)
        {
            return;
        }

        if (!jeringa.activeSelf)
    {
        jeringa.SetActive(true);
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
                    StartCoroutine(Esperar3());

                }
            }
        }
    }
     IEnumerator Esperar3()
    {
        yield return new WaitForSeconds(3f);
        gameManagerCuatro.instancia.AvanzarPaso();
    }
}
