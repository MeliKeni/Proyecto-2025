using UnityEngine;

public enum PasoRadiografia
{
    AbrirArmario,
    ColocarChaleco,
    PacienteMaquina,
    IniciarRadiografia,
    GestoComputadora,
    Escaneo,
    SalirDeMaquina,
    RetirarChaleco,
    ImprimirEstudio,
    EntregarSobre,
    Completado
}

public class GameManager3 : MonoBehaviour
{
    public static GameManager3 instancia;
    public PasoRadiografia pasoActual = PasoRadiografia.AbrirArmario;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Siempre arranca en el primer paso
        pasoActual = PasoRadiografia.AbrirArmario;
        UIManager3.instancia.ActualizarInstruccion(pasoActual);
    }

    public void AvanzarPaso()
    {
        if (pasoActual == PasoRadiografia.Completado)
        {
            Debug.Log("El estudio ya está completado");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual);
        UIManager3.instancia.ActualizarInstruccion(pasoActual);
    }

    public bool EsPaso(PasoRadiografia paso)
    {
        return pasoActual == paso;
    }

    public void ErrorPaso()
    {
        Debug.LogWarning("Intentaste hacer una acción fuera de orden.");
        // Acá podés poner sonido o feedback visual
    }
    public void ResetGame()
    {
        pasoActual = PasoRadiografia.AbrirArmario;
        UIManager3.instancia.ActualizarInstruccion(pasoActual);
    }
}
