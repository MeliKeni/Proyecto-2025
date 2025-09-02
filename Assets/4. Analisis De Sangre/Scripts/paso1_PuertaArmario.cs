using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso1_PuertaArmario : MonoBehaviour
{
    public GameObject puerta;
    public float velocidadRotacion = 90f; // grados por segundo
    private bool abrir = false;
    private float anguloRotado = 0f;
    public Camera MyCurrentCam;

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.AbrirArmario)
        {
            return;
        }

        if (!abrir)  //si no esta abieirto 
        {
            // Detectar click y ahi abrir
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == puerta)
                    {
                        abrir = true;
                    }
                }
            }
        }
        else //aca es si abrir es true
        {
            
        }
    }
}

