using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso4_5_SacarAlgodon : MonoBehaviour
{
    public GameObject armario;
    public Camera MyCurrentCam;
    public bool pasoTerminado4_5 = false;
   
    void Update()
    {
        return;
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == armario)
                {
                    pasoTerminado4_5 = true;
                    gameManagerCuatro.instancia.AvanzarPaso();

                }
            }
        }
    }
}
