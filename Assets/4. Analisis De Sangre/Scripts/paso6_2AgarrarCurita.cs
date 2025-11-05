using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso6_2AgarrarCurita : MonoBehaviour
{ 
    public Camera MyCurrentCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.AgarrarCurita)
        {
            return;
        }
       
    }
}
