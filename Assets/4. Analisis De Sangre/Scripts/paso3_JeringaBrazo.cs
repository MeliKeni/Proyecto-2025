using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso3_JeringaBrazo : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject jeringa;
    public Camera MyCurrentCam;

    [Tooltip("Si querés, podés dejar esto en null y buscar el paciente por tag cuando haga overlap")]
    public GameObject paciente;

    [Header("Ajustes de colocación")]
    public float alturaSobrePaciente = 1.0f; // cuan arriba va a estar del paciente
    public float overlapRadius = 0.6f;       // radio de detección con el paciente
    public bool autoSoltarAlTocar = true;    // si true, suelta automáticamente al tocar paciente

    private bool arrastrando = false;
    private float zFija; // para mantener Z fijo
    private GameObject pacienteEnColision = null;

    void Update()
    {
        // Solo funciona en el paso correcto
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.ColocarGuante)
            return;

        // Detectar click en la jeringa
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.collider != null && hit.collider.gameObject == jeringa)
                {
                    arrastrando = true;
                    zFija = jeringa.transform.position.z;
                }
            }
        }

        // Arrastrar jeringa
        if (arrastrando)
        {
            Vector3 mousePos = Input.mousePosition;
            float distanciaCam = Mathf.Abs(MyCurrentCam.transform.position.z - zFija);
            mousePos.z = distanciaCam;

            Vector3 worldPos = MyCurrentCam.ScreenToWorldPoint(mousePos);
            jeringa.transform.position = new Vector3(worldPos.x, worldPos.y, zFija);

            // Detectar paciente cerca
            Collider[] hits = Physics.OverlapSphere(jeringa.transform.position, overlapRadius);
            pacienteEnColision = null;
            foreach (var c in hits)
            {
                if (c.gameObject == jeringa) continue;
                if (c.CompareTag("Paciente"))
                {
                    pacienteEnColision = c.gameObject;
                    break;
                }
            }

            // Soltar automáticamente si corresponde
            if (autoSoltarAlTocar && pacienteEnColision != null)
            {
                SoltarYColocar();
            }
        }

        // Al soltar el mouse
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

        // Colocar sobre el paciente
        Vector3 nuevaPos = pacienteEnColision.transform.position;
        nuevaPos.y += alturaSobrePaciente;
        jeringa.transform.position = nuevaPos;

        // Hacer hijo del paciente
        jeringa.transform.SetParent(pacienteEnColision.transform, false);

        // Avanzar paso
        if (gameManagerCuatro.instancia != null)
            gameManagerCuatro.instancia.AvanzarPaso();

        // Reset
        pacienteEnColision = null;
        arrastrando = false;
    }

    // Opcional: para ver el área de detección en el editor
    private void OnDrawGizmosSelected()
    {
        if (jeringa != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(jeringa.transform.position, overlapRadius);
        }
    }
}