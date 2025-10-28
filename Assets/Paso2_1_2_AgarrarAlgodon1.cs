using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso2_1_2_AgarrarAlgodon1 : MonoBehaviour
{
    public Camera MyCurrentCam;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Algodon"))
                {
                    gameManagerCuatro.instancia.AvanzarPaso();

                }
            }
        }
    }
}
