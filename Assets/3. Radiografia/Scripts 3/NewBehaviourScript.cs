using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int orden; // Qué número de punto es
    private RutaManager rutaManager;

    void Start()
    {
        rutaManager = FindObjectOfType<RutaManager>();
    }

    // Esto detecta si el mouse está tocando el punto
    public void RevisarPunto()
    {
        rutaManager.PuntoTocado(orden);
    }
}
