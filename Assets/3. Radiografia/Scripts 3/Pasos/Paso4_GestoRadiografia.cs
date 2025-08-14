using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso4_GestoRadiografia : MonoBehaviour
{
    public GameObject ImagenGesto; // La imagen en el Canvas que queremos mostrar/ocultar
    public GameObject Maquina;     // El objeto que se clickea para mostrar la imagen
    public Camera MyCurrentCam;

    private bool imagenVisible = false;

    void Start()
    {
        // Al inicio, la imagen debe estar oculta
        if (ImagenGesto != null)
            ImagenGesto.SetActive(false);
    }

    void Update()
    {
        // Solo funciona si estamos en el paso GestoComputadora
        if (GameManager3.instancia.pasoActual != PasoRadiografia.GestoComputadora)
        {
            // Aseguramos que la imagen esté oculta si no estamos en el paso
            if (ImagenGesto != null && ImagenGesto.activeSelf)
                ImagenGesto.SetActive(false);
            return;
        }

        // Detectar click en la máquina para mostrar la imagen
        if (Input.GetMouseButtonDown(0) && !imagenVisible)
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == Maquina)
                {
                    if (ImagenGesto != null)
                    {
                        ImagenGesto.SetActive(true);
                        imagenVisible = true;
                    }
                }
            }
        }

        // Si la imagen está visible y el usuario presiona 'A', ocultarla y avanzar paso
        if (imagenVisible && Input.GetKeyDown(KeyCode.A))
        {
            if (ImagenGesto != null)
            {
                ImagenGesto.SetActive(false);
                imagenVisible = false;

                // Avanzar al siguiente paso
                GameManager3.instancia.AvanzarPaso();
            }
        }
    }
}
