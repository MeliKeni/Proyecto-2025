using UnityEngine;

public class Paso1_PonerChaleco : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject chaleco;               
    [Tooltip("Si querés, podés dejar esto en null y buscar el paciente por tag cuando haga overlap")]
    public GameObject paciente;              

    [Header("Ajustes de colocación")]
    public float alturaSobrePaciente = 1.0f; // cuan arriba va a estar del paciente, 
    public float overlapRadius = 0.6f;       // cucando ya detecta la colision
    public bool autoSoltarAlTocar = true;    // si true, suelta automáticamente al tocar paciente, si false, hay que  soltar mouse

    bool arrastrando = false;
    float zFija; // para que no se mueva en el eje z
    GameObject pacienteEnColision = null;  // esta en colision con el paciente

    public Camera MyCurrentCam;

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.ColocarChaleco)
        {
            return; // anulamos todo si no estamos en el paso que hay que estar
        }
        //detecta si hace click en chaleco 
        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider != null && h.collider.gameObject == chaleco)
                {
                    arrastrando = true; //lo esta intentando arrastrar
                    zFija = chaleco.transform.position.z;  //guartda la posicion en z para que no se vaya para atrasc
                }
            }
        }

        // Arrastrar funcionalidad
        if (arrastrando)
        {
            Vector3 mouse = Input.mousePosition; 
            // distancia desde la cámara hasta la Z fija del chaleco
            float distanciaCam = Mathf.Abs(MyCurrentCam.transform.position.z - zFija);
            mouse.z = distanciaCam;
            Vector3 world = MyCurrentCam.ScreenToWorldPoint(mouse); //llama world.x, world.y y world.z a las posciones de el mouse

            // seguir solo X,Y y mantener Z fijo
            chaleco.transform.position = new Vector3(world.x, world.y, zFija); // mueve el chaleco

            // se fija si ya esta tocando al paciente
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
        chaleco.transform.SetParent(pacienteEnColision.transform, true);

        // Avanzar paso
        if (GameManager3.instancia != null)
            GameManager3.instancia.AvanzarPaso();

        // reset
        pacienteEnColision = null;
        arrastrando = false;
    }

   
}
