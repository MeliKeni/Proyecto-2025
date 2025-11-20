using UnityEngine;

public class movimiento : MonoBehaviour
{
    public Transform pinchazoTR;
    public float velocidad = 5f;
    public float velocidadRotacion = 5f;

    void Update()
    {
        // Mover la cámara hacia el pinchazo
        transform.position = Vector3.Lerp(
            transform.position,
            pinchazoTR.position,
            Time.deltaTime * velocidad
        );

        // Rotar la cámara mirando al pinchazo
        Vector3 direccion = (pinchazoTR.position - transform.position).normalized;

        if (direccion != Vector3.zero)
        {
            Quaternion rotObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotObjetivo,
                Time.deltaTime * velocidadRotacion
            );
        }
    }
}

