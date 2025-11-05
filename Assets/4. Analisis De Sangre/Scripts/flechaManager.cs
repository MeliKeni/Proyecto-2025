using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flechaManager : MonoBehaviour
{
    [SerializeField] RawImage[] flecha;
    public gameManagerCuatro gameManager;

    void Start()
    {
        for (int i = 0; i < flecha.Length; i++)
        {
            flecha[i].gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PacienteSilla)
        {
            flecha[0].gameObject.SetActive(true);
            flecha[1].gameObject.SetActive(true);
        }
        else
        {

            flecha[0].gameObject.SetActive(false);
            flecha[1].gameObject.SetActive(false);
        }
    }
}
