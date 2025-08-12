using UnityEngine;

public class Paso1_PonerChaleco : MonoBehaviour
{
    public GameObject chaleco;
    public GameObject paciente;
    public float distanciaAceptable = 0.5f;
    private bool arrastrando = false;
    private Vector3 offset;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == chaleco)
                {
                    arrastrando = true;
                    Vector3 puntoClick = hit.point;
                    offset = chaleco.transform.position - puntoClick;
                }
            }
        }

        if (arrastrando)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Plano dinámico en la altura actual del chaleco para evitar que "desaparezca"
            Plane plano = new Plane(Vector3.up, chaleco.transform.position);

            float distancia;
            if (plano.Raycast(ray, out distancia))
            {
                Vector3 puntoEnPlano = ray.GetPoint(distancia);
                chaleco.transform.position = puntoEnPlano + offset;
            }
        }

        if (Input.GetMouseButtonUp(0) && arrastrando)
        {
            arrastrando = false;

            float distancia = Vector3.Distance(chaleco.transform.position, paciente.transform.position);

            if (distancia < distanciaAceptable)
            {
                Vector3 nuevaPos = paciente.transform.position;
                nuevaPos.y += 1.0f;
                chaleco.transform.position = nuevaPos;

                GameManager3.instancia.AvanzarPaso();
            }
        }
    }
}
