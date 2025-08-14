using UnityEngine;

public class Paso8_EntregarEstudio : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject estudioImpreso;          // Objeto que se arrastra
    public string tagPaciente = "Paciente";    // Tag del cubo paciente (asegurate que el cubo tenga ese tag)

    [Header("Ajustes")]
    public float alturaSobrePaciente = 1.0f;   // Altura sobre el paciente donde se dejará el estudio
    public float overlapRadius = 0.6f;         // Radio para detectar el paciente cerca
    public bool autoSoltarAlTocar = true;      // Si true suelta automáticamente al tocar, si false requiere soltar botón

    // Estado interno
    bool arrastrando = false;
    float zFija;
    GameObject pacienteEnColision = null;

public Camera MyCurrentCam;
    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.EntregarSobre)
            return;  // Solo funciona si estamos en el paso correcto

        // 1) Inicio de arrastre: clic sobre el estudio impreso
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider != null && h.collider.gameObject == estudioImpreso)
                {
                    arrastrando = true;
                    zFija = estudioImpreso.transform.position.z; // guardar Z fijo
                }
            }
        }

        // 2) Mientras arrastramos: mover el estudio (X,Y), Z fijo
        if (arrastrando)
        {
            Vector3 mouse = Input.mousePosition;
            float distanciaCam = Mathf.Abs(MyCurrentCam.transform.position.z - zFija);
            mouse.z = distanciaCam;
            Vector3 world = MyCurrentCam.ScreenToWorldPoint(mouse);

            estudioImpreso.transform.position = new Vector3(world.x, world.y, zFija);

            // 3) Chequear colisiones con paciente
            Collider[] hits = Physics.OverlapSphere(estudioImpreso.transform.position, overlapRadius);
            pacienteEnColision = null;
            foreach (var c in hits)
            {
                if (c.gameObject == estudioImpreso) continue;
                if (c.CompareTag(tagPaciente))
                {
                    pacienteEnColision = c.gameObject;
                    break;
                }
            }

            // 4) Auto soltar si está sobre paciente y está activado
            if (autoSoltarAlTocar && pacienteEnColision != null)
            {
                SoltarYColocar();
            }
        }

        // 5) Al soltar el botón del mouse
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
        estudioImpreso.transform.position = nuevaPos;

        // Opcional: hacerlo hijo del paciente
        // estudioImpreso.transform.SetParent(pacienteEnColision.transform, true);

        GameManager3.instancia.AvanzarPaso();

        pacienteEnColision = null;
        arrastrando = false;
    }

   
}
