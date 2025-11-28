using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso7_PonerCurita : MonoBehaviour
{
        public Camera MyCurrentCam;
    public bool curitapuesta = false;

    public uIManagerCuatro uiManager;

    public Animator anim;
    public GameObject liga;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Pararse", false);
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
                    curitapuesta = true;
                    Cursor.SetCursor(null, default, CursorMode.Auto);

                    uiManager.avanzarTag = true;
            StartCoroutine(Esperar2());
                    StartCoroutine(Esperar6());


                }
            }
            IEnumerator Esperar2()
    {
        yield return new WaitForSeconds(1f);
                liga.SetActive(false);
                anim.SetBool("Pararse", true);
               


    }

            IEnumerator Esperar6()
            {
                yield return new WaitForSeconds(8f);
             
                gameManagerCuatro.instancia.AvanzarPaso();

            }
        }
    }
}
