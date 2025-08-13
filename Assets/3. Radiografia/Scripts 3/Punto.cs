using UnityEngine;
using UnityEngine.EventSystems;

public class Punto : MonoBehaviour, IPointerEnterHandler
{
    public int orden; // Orden del punto en la secuencia
    private RutaManager rutaManager;

    void Start()
    {
        rutaManager = FindObjectOfType<RutaManager>();
    }

    // Esto se llama automáticamente cuando el mouse pasa por el punto
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Solo cuenta si el mouse está presionado
        if (Input.GetMouseButton(0))
        {
            rutaManager.PuntoTocado(orden);
        }
    }
}
