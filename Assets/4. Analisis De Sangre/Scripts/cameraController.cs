using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform[] views; // distintas perspectivas
    public float transitionSpeed;
    Transform currentView;
    public bool cursorJeringa = false;
    public Paso2_1_2_AgarrarAlgodon1 paso2_1_2script;



    void Start()
    {
        currentView = transform;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // click izquierdo
        {
            // Lanza un rayo desde la cámara hacia la posición del mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // --- GUANTE ---
                if (hit.collider.CompareTag("Guante"))
                {
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.ColocarGuante))
                    {
                        currentView = views[0];
                    }
                    else
                    {
                        gameManagerCuatro.instancia.ErrorPaso();
                    }
                }

                // --- JERINGA ---
                else if (hit.collider.CompareTag("Jeringa"))
                {
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AgarrarJeringa))
                    {
                        currentView = views[0];
                        gameManagerCuatro.instancia.AvanzarPaso();
                        cursorJeringa = true;

}
                    else
                    {
                        gameManagerCuatro.instancia.ErrorPaso();
                    }
                }

                // --- BRAZO ---
                else if (hit.collider.CompareTag("Brazo"))
                {
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.JeringaBrazo))
                    {
                        currentView = views[2];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.SangreSacada))
                    {
                        currentView = views[0];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                     if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.LlevarAlgodon))
                    {
                        currentView = views[2];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.PonerAlgodon))
                    {
                        currentView = views[0];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                    else
                    {
                        gameManagerCuatro.instancia.ErrorPaso();
                    }
                }

                // --- ARMARIO ---
                else if (hit.collider.CompareTag("Armario"))
                {
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AgarrarGuante))
                    {
                        currentView = views[1];
                    }
                    else if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AbrirArmario2))
                    {
                        currentView = views[1];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                      else if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AbrirArmario3))
                    {
                        currentView = views[1];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                    else if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AbrirArmario2_5))
                    {
                        currentView = views[1];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                    else
                    {
                        gameManagerCuatro.instancia.ErrorPaso();
                    }
                }

                // --- APOYA BRAZO ---
                else if (hit.collider.CompareTag("ApoyaBrazo"))
                {
                    currentView = views[2];
                }

                if (hit.collider.CompareTag("Algodon"))
                {
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AgarrarAlgodon))
                    {
                        currentView = views[0];
                        gameManagerCuatro.instancia.AvanzarPaso();
                    }
                    else
                    {
                        gameManagerCuatro.instancia.ErrorPaso();
                    }
                }

                if (paso2_1_2script.cambiarCamara == true)
                    
                    {
                        currentView = views[0];
                         paso2_1_2script.cambiarCamara = false;
                    
                }
            }


        }
    }

    private void LateUpdate()
    {
        // Movimiento suave
        transform.position = Vector3.Lerp(
            transform.position,
            currentView.position,
            Time.deltaTime * transitionSpeed
        );

        // Rotación suave
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            currentView.rotation,
            Time.deltaTime * transitionSpeed
        );
    }
}
