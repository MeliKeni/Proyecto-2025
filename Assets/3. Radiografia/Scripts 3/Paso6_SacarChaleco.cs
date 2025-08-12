using UnityEngine;

public class Paso6_SacarChaleco : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject chaleco;               // la esfera (mismo objeto que antes)

    [Header("Ajustes de colocación")]
    public float alturaSobreArmario = 1.0f; // altura final sobre el armario
    public float overlapRadius = 0.6f;       // radio para detectar colisión
    public bool autoSoltarAlTocar = true;    // soltar automáticamente al tocar armario

    // Estado interno
    bool arrastrando = false;
    float zFija;
    GameObject armarioEnColision = null;

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.RetirarChaleco)
        {
            return; // solo funciona en paso RetirarChaleco
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
                    zFija = chaleco.transform.position.z; // mantener Z fijo
                }
            }
        }

        // 2) Mientras arrastramos: mover chaleco X,Y (Z constante)
        if (arrastrando)
        {
            Vector3 mouse = Input.mousePosition;
            float distanciaCam = Mathf.Abs(Camera.main.transform.position.z - zFija);
            mouse.z = distanciaCam;
            Vector3 world = Camera.main.ScreenToWorldPoint(mouse);

            chaleco.transform.position = new Vector3(world.x, world.y, zFija);

            // 3) chequeo de overlap: buscar armario cercano
            Collider[] hits = Physics.OverlapSphere(chaleco.transform.position, overlapRadius);
            armarioEnColision = null;
            foreach (var c in hits)
            {
                if (c.gameObject == chaleco) continue;
                if (c.CompareTag("Armario"))
                {
                    armarioEnColision = c.gameObject;
                    break;
                }
            }

            // 4) soltar automáticamente si tocamos armario
            if (autoSoltarAlTocar && armarioEnColision != null)
            {
                SoltarYColocar();
            }
        }

        // 5) Al soltar botón mouse
        if (Input.GetMouseButtonUp(0) && arrastrando)
        {
            arrastrando = false;

            if (armarioEnColision != null)
            {
                SoltarYColocar();
            }
        }
    }

    void SoltarYColocar()
    {
        if (armarioEnColision == null) return;

        // Colocar chaleco sobre el armario
        Vector3 nuevaPos = armarioEnColision.transform.position;
        nuevaPos.y += alturaSobreArmario;
        chaleco.transform.position = nuevaPos;

        // Opcional: hacer chaleco hijo del armario para que se mueva con él
        // chaleco.transform.SetParent(armarioEnColision.transform, true);

        // Avanzar paso
        if (GameManager3.instancia != null)
            GameManager3.instancia.AvanzarPaso();

        // reset
        armarioEnColision = null;
        arrastrando = false;
    }

    // Gizmo para ver radio de detección
    private void OnDrawGizmosSelected()
    {
        if (chaleco == null) return;
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(chaleco.transform.position, overlapRadius);
    }
}
