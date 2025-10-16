using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso8_AgarrarGuante : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Verifica que estemos en el paso correcto antes de avanzar
            if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AgarrarGuante))
            {
                gameManagerCuatro.instancia.AvanzarPaso();
            }
            else
            {
                gameManagerCuatro.instancia.ErrorPaso();
            }
        }
    }
}
