using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso5_PonerAlgodon : MonoBehaviour
{
/*    [Header("Referencias")]
    public GameObject algodon;
    public GameObject paciente;

    [Header("Ajustes de colocación")]
    public float alturaSobrePaciente = 1.0f; 
    public float overlapRadius = 0.6f;       
    public bool autoSoltarAlTocar = true;    

    bool arrastrando = false;
    float zFija; 
    private GameObject pacienteEnColision = null;  

    public Camera MyCurrentCam;

    void Update()
    {

        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.PonerAlgodon)
        {
            return;
        }

        // Detectar click en el algodón
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider != null && h.collider.gameObject == algodon)
                {
                    arrastrando = true;
                    zFija = algodon.transform.position.z;
                }
            }
        }

        // --- Arrastrar ---
        if (arrastrando)
        {
            Vector3 mouse = Input.mousePosition;
            float distanciaCam = Mathf.Abs(MyCurrentCam.transform.position.z - zFija);
            mouse.z = distanciaCam;
            Vector3 world = MyCurrentCam.ScreenToWorldPoint(mouse);

            algodon.transform.position = new Vector3(world.x, world.y, zFija);

            // detectar colisión con paciente
            Collider[] hits = Physics.OverlapSphere(algodon.transform.position, overlapRadius);
            pacienteEnColision = null;
            foreach (var c in hits)
            {
                if (c.gameObject == algodon) continue;
                if (c.CompareTag("Paciente"))
                {
                    pacienteEnColision = c.gameObject;
                    break;
                }
            }

            if (autoSoltarAlTocar && pacienteEnColision != null)
            {
                SoltarYColocar();
            }
        }

        // Suelta al dejar de clickear
        if (Input.GetMouseButtonUp(0) && arrastrando)
        {
            arrastrando = false;

            if (pacienteEnColision != null)
            {
                SoltarYColocar();
            }
        }
    }

    void SoltarYColocar()
    {
        if (pacienteEnColision == null) return;

        Vector3 nuevaPos = pacienteEnColision.transform.position;
        nuevaPos.y += alturaSobrePaciente;
        algodon.transform.position = nuevaPos;

        algodon.transform.SetParent(pacienteEnColision.transform, true);

        if (gameManagerCuatro.instancia != null)
            gameManagerCuatro.instancia.AvanzarPaso();

        pacienteEnColision = null;
        arrastrando = false;
    }*/
}
