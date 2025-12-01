using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paso6_GuardarSangre : MonoBehaviour
{
    public Image Jeringaimg;
    public GameObject Jeringa;
    public Camera MyCurrentCam;
    public Animator animJeringa;
    public Animator animFrasco;
    public bool CursorJeringa = false;
    public bool pasoTerminado = false;

    void Start()
    {   
        Jeringa.SetActive(false);
        animJeringa.SetBool("JeringaGuardar", false);
        animFrasco.SetBool("Llenar", false);
        CursorJeringa = true;
        Jeringaimg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.GuardarSangre)
        {
            return;
        }
        

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider.CompareTag("Frasco"))
                {
                    CursorJeringa = false;
                    Cursor.SetCursor(null, default, CursorMode.Auto);
                    Jeringa.SetActive(true);
                    animJeringa.SetBool("JeringaGuardar", true);
                    animFrasco.SetBool("Llenar", true);
                    pasoTerminado = true;
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
