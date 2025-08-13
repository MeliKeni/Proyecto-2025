using UnityEngine;
using UnityEngine.UI;

public class Paso5_HacerEstudio : MonoBehaviour
{
    public Slider barraCarga;        // Asignar en inspector el Slider UI
    public float duracionCarga = 5f; // Tiempo que tarda en llenarse la barra
    public GameObject paciente; 

    private float tiempoAcumulado = 0f;

    void Start()
    {
        if (barraCarga != null)
        {
            barraCarga.gameObject.SetActive(false); // Ocultar al inicio
            barraCarga.value = 0f;
        }
    }

    void Update()
    {
        if (barraCarga == null) return;

        if (GameManager3.instancia.pasoActual == PasoRadiografia.Escaneo)
        {
            if (!barraCarga.gameObject.activeSelf)
                barraCarga.gameObject.SetActive(true); // Mostrar barra al entrar

            // Acumular tiempo y actualizar barra
            tiempoAcumulado += Time.deltaTime;
            barraCarga.value = Mathf.Clamp01(tiempoAcumulado / duracionCarga);

            if (barraCarga.value >= 1f)
            {
                GameManager3.instancia.AvanzarPaso();
                tiempoAcumulado = 0f;
                barraCarga.value = 0f;
                barraCarga.gameObject.SetActive(false);

                //paciente se mueve afuera de la maquina
                   

            }
        }
        else
        {
            if (barraCarga.gameObject.activeSelf)
                barraCarga.gameObject.SetActive(false); // Ocultar barra si no está en paso

            tiempoAcumulado = 0f;
            barraCarga.value = 0f;
        }
    }
}
