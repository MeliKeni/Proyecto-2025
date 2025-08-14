using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paso3_EmpezarRadiografia : MonoBehaviour
{
    public GameObject esfera;           // La esfera a la que se le hace click
    public GameObject objetoACambiar;   // El cubo u objeto cuyo material cambiará
    public Material nuevoMaterial;      // El material nuevo que queremos asignar
    public Camera MyCurrentCam;

    private bool cambioHecho = false;  // Para que solo cambie una vez

    void Update()
    {
        // Solo funciona en el paso IniciarRadiografia
        if (GameManager3.instancia.pasoActual != PasoRadiografia.IniciarRadiografia)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && !cambioHecho)
        {
            Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == esfera)
                {
                    CambiarMaterial();
                }
            }
        }
    }

    void CambiarMaterial()
    {
        if (objetoACambiar != null && nuevoMaterial != null)
        {
            Renderer rend = objetoACambiar.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = nuevoMaterial;
                cambioHecho = true;  // Ya se hizo el cambio, no volver a hacerlo
            }
            else
            {
                Debug.LogWarning("El objeto no tiene Renderer");
            }
        }
        else
        {
            Debug.LogWarning("Falta asignar objeto o material");
        }

        GameManager3.instancia.AvanzarPaso();

    }
}
