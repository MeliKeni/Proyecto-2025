using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PasoRadiografia //los pasos a seguir
{
    AbrirArmario,
    ColocarChaleco,
    PacienteMaquina,
    IniciarRadiografia,
    GestoComputadora,
    Escaneo,
    RetirarChaleco,
    ImprimirEstudio,
    EntregarSobre,
    Completado
}


public class GameManager3 : MonoBehaviour
{

    public static GameManager3 instancia; //para que todos puedan acceder al gamemanager
    public PasoRadiografia pasoActual = PasoRadiografia.AbrirArmario; //define el paso inicial


    private void Awake() //para que haya solo un gameobject
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UIManager3.instancia.ActualizarInstruccion(pasoActual);
    }

    public void AvanzarPaso() //avanzar de paso
    {
        if (pasoActual == PasoRadiografia.Completado)
        {
            Debug.Log("El estudio ya está completado");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());

        UIManager3.instancia.ActualizarInstruccion(pasoActual);
    }

    public bool EsPaso(PasoRadiografia paso) //es lo que van a usar otros codigos para saber si ya estan en el paso en el que realizan cierta accion
    {
        return pasoActual == paso;
    }

    public void ErrorPaso() //errores
    {
        Debug.LogWarning("Intentaste hacer una acción fuera de orden.");
        //  poner sonido o feedback visual
    }
}
