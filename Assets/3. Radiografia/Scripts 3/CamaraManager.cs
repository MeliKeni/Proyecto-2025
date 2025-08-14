using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera Camara1;
    public Camera Camara2;
    public GameManager3 GameManager;
    void Start()
    {
        Camara1.gameObject.SetActive(true);
        Camara2.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager3.instancia.pasoActual == PasoRadiografia.IniciarRadiografia)
        {

            Camara1.gameObject.SetActive(false);
            Camara2.gameObject.SetActive(true);
        }
        if (GameManager3.instancia.pasoActual == PasoRadiografia.SalirDeMaquina)
        {

            Camara1.gameObject.SetActive(true);
            Camara2.gameObject.SetActive(false);
        }
    }
}
