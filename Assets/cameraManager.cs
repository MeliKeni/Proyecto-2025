using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera Camara1;
    public Camera Camara2;
    public gameManagerCuatro GameManager;
    void Start()
    {
        Camara1.gameObject.SetActive(true);
        Camara2.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.SacarSangre)
        {

            Camara1.gameObject.SetActive(false);
            Camara2.gameObject.SetActive(true);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PonerAlgodon)
        {

            Camara1.gameObject.SetActive(true);
            Camara2.gameObject.SetActive(false);
        }
    }
}
