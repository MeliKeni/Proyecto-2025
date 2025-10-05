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
                    currentView = views[1];
                }
               
               if (hit.collider.CompareTag("ApoyaBrazo"))
                {
                    currentView = views[2];
                }
            }
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3 (
            Mathf.Lerp(transform.rotation.eulerAngles.x,currentView.transform.rotation.eulerAngles.x,Time.deltaTime * transitionSpeed),
            Mathf.Lerp(transform.rotation.eulerAngles.y,currentView.transform.rotation.eulerAngles.y,Time.deltaTime * transitionSpeed),
            Mathf.Lerp(transform.rotation.eulerAngles.z,currentView.transform.rotation.eulerAngles.z,Time.deltaTime * transitionSpeed)
        );

        transform.eulerAngles = currentAngle;
    }
}
