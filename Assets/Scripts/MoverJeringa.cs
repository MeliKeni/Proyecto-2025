using UnityEngine;

public class MoverJeringa : MonoBehaviour
{
    public Transform punta;      // Asigná el empty "Punta"
    public Transform objetivo;   // Asigná la Esfera
    public float velocidad = 2f; // Velocidad del movimiento
    public bool mover = false;

    private Vector3 offset;

    void Start()
    {
        // Calculamos la diferencia entre el pivote de la jeringa y su punta
        offset = transform.position - punta.position;
    }

    void Update()
    {
        if (mover)
        {
            // Posición deseada para que la punta llegue al objetivo
            Vector3 destino = objetivo.position + offset;

            // Interpolación suave (Lerp)
            transform.position = Vector3.Lerp(transform.position, destino, Time.deltaTime * velocidad);

            // Opcional: que la jeringa mire al objetivo
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(objetivo.position - punta.position), Time.deltaTime * velocidad);
        }
    }
}

