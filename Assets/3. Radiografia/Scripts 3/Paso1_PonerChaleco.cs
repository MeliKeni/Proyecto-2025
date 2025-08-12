using UnityEngine;

public class Paso1_PonerChaleco : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject chaleco;               // la esfera
    [Tooltip("Si querés, podés dejar esto en null y buscar el paciente por tag cuando haga overlap")]
    public GameObject paciente;              // opcional: referencia directa al paciente (puede ser null)

    [Header("Ajustes de colocación")]
    public float alturaSobrePaciente = 1.0f; // altura final sobre el paciente
    public float overlapRadius = 0.6f;       // radio para detectar colisión (ajustá según escala)
    public bool autoSoltarAlTocar = true;    // si true, suelta automáticamente al tocar paciente; si false, requiere soltar mouse

    // Estado interno
    bool arrastrando = false;
    float zFija;
    GameObject pacienteEnColision = null;

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.ColocarChaleco)
        {
            return; // anulamos todo si no estamos en el paso que hay que estar
        }
        // 1) Inicio de arrastre: clic sobre la esfera
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider != null && h.collider.gameObject == chaleco)
                {
                    arrastrando = true;
                    zFija = chaleco.transform.position.z; // guardo Z para mantenerlo fijo durante el drag
                }
            }
        }

        // 2) Mientras arrastramos: mover chaleco X,Y (Z constante)
        if (arrastrando)
        {
            Vector3 mouse = Input.mousePosition;
            // distancia desde la cámara hasta la Z fija del chaleco
            float distanciaCam = Mathf.Abs(Camera.main.transform.position.z - zFija);
            mouse.z = distanciaCam;
            Vector3 world = Camera.main.ScreenToWorldPoint(mouse);

            // seguir solo X,Y y mantener Z fijo
            chaleco.transform.position = new Vector3(world.x, world.y, zFija);

            // 3) chequeo de overlap: buscamos colliders cercanos al chaleco
            Collider[] hits = Physics.OverlapSphere(chaleco.transform.position, overlapRadius);
            pacienteEnColision = null;
            foreach (var c in hits)
            {
                if (c.gameObject == chaleco) continue;           // ignorar a sí mismo
                if (c.CompareTag("Paciente"))
                {
                    pacienteEnColision = c.gameObject;
                    break;
                }
            }

            // 4) si queremos soltar automáticamente al tocar:
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

        // Colocar sobre el paciente
        Vector3 nuevaPos = pacienteEnColision.transform.position;
        nuevaPos.y += alturaSobrePaciente;
        chaleco.transform.position = nuevaPos;

        // Opcional: hacer al chaleco hijo del paciente para que se mueva con él
        // chaleco.transform.SetParent(pacienteEnColision.transform, true);

        // Avanzar paso
        if (GameManager3.instancia != null)
            GameManager3.instancia.AvanzarPaso();

        // reset
        pacienteEnColision = null;
        arrastrando = false;
    }

    // Gizmo para ver el radio de detección en Scene view (solo cuando seleccionás el GameObject)
    private void OnDrawGizmosSelected()
    {
        if (chaleco == null) return;
        Gizmos.color = new Color(0, 1, 1, 0.5f);
        Gizmos.DrawWireSphere(chaleco.transform.position, overlapRadius);
    }
}
