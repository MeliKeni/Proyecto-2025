using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso6_GuardarSangre : MonoBehaviour
{
    public GameObject Jeringa;
    public Camera MyCurrentCam;
    public Animator animJeringa;
    public Animator animFrasco;

    void Start()
    {
        Jeringa.SetActive(false);
        animJeringa.SetBool("JeringaGuardar", false);
        animFrasco.SetBool("Llenar", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.GuardarSangre)
        {
            return;
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.GuardarSangre)
        {
            Jeringa.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider.CompareTag("Jeringa"))
                {
                    animJeringa.SetBool("JeringaGuardar", false);
                    animFrasco.SetBool("Llenar", true);
                    StartCoroutine(Esperar4());

                }
            }
        }

    }
    IEnumerator Esperar4()
    {
        yield return new WaitForSeconds(3f);
        Jeringa.SetActive(false);
        gameManagerCuatro.instancia.AvanzarPaso();
    }
}
