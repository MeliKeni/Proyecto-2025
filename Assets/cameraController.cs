using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
  public Transform[] views; // distintas perspectivas
    public float transitionSpeed;
    Transform currentView;

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
                // según el objeto clickeado, cambio la cámara
                if (hit.collider.CompareTag("Silla"))
                {
                    currentView = views[0];
                }

                if (hit.collider.CompareTag("Armario"))
                {
                    if (gameManagerCuatro.instancia.EsPaso(PasoAnalisisDeSangre.AgarrarGuante))
                    {
                        currentView = views[1];
                    }
                    else
                    {
                        gameManagerCuatro.instancia.ErrorPaso();
                    }

                    if (hit.collider.CompareTag("ApoyaBrazo"))
                    {
                        currentView = views[2];
                    }
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


