using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PasoAnalisisDeSangre //los pasos a seguir
{
    PacienteSilla,  //0
    AbrirArmario,   //1 
    ColocarGuante, //2
    JeringaBrazo, //3
    SacarSangre, //4
    PonerAlgodon, //5
    GuardarSangre, //6
    PonerCurita, //7
    Completado
}

public class gameManagerCuatro : MonoBehaviour
{
    public static gameManagerCuatro instancia; //para que todos puedan acceder al gamemanager
    public PasoAnalisisDeSangre pasoActual = PasoAnalisisDeSangre.PacienteSilla; //define el paso inicial

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
        uIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
    }

    public void AvanzarPaso() //avanzar de paso
    {
        if (pasoActual == PasoAnalisisDeSangre.Completado)
        {
            Debug.Log("El estudio ya está completado");
            return;
        }

        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual.ToString());

        uIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
    }

    public bool EsPaso(PasoAnalisisDeSangre paso) //es lo que van a usar otros codigos para saber si ya estan en el paso en el que realizan cierta accion
    {
        return pasoActual == paso;
    }

    public void ErrorPaso() //errores
    {
        Debug.LogWarning("Intentaste hacer una acción fuera de orden.");
        //  poner sonido o feedback visual
    }
    //creo que las ultimas dos funciones se pueden ir, probar manana 
}

