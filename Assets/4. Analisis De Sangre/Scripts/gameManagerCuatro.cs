using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PasoAnalisisDeSangre // Los pasos a seguir
{
    PacienteSilla,  //0
    AbrirArmario,   //1 
    AgarrarGuante, // 
    ColocarGuante,  //2
    AbrirArmario2, //2.0
    PonerAlcohol, //2.1
    AgarrarAlgodon1, //2.2
    PonerAlgodon1, //2.3
    TirarAlgodon, //2.4
    AbrirArmario2_5,// 2.5
    AgarrarJeringa, //2.6
    JeringaBrazo,   //3
    SacarSangre,    //4
    SangreSacada,
    AbrirArmario3, //4,1
    AgarrarAlgodon,   //4.5
    LlevarAlgodon, 
    PonerAlgodon,   //5 
    GuardarSangre,  //6
    SangreGuardada,
    AbrirArmario4,   //6.1 
    AgarrarCurita,  //6.2
    PonerCurita,    //7
    Completado
}

public class gameManagerCuatro : MonoBehaviour
{
    public static gameManagerCuatro instancia; // Singleton
    public PasoAnalisisDeSangre pasoActual = PasoAnalisisDeSangre.PacienteSilla; // Paso inicial

    public string TagDeseada = "Paciente";
    public GameObject panel;
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
        TagDeseada = "Paciente";

    }

    private void Start()
    {
        // Si el UI ya existe, actualizamos la instrucción
        if (uIManagerCuatro.instancia != null)
        {
            uIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
        }

        else
        {
            Debug.LogWarning("UIManagerCuatro no está listo aún. Se actualizará más tarde.");
        }
        pasoActual = PasoAnalisisDeSangre.PacienteSilla;
    }

    // Llamado por UIManagerCuatro cuando se inicializa
    public void ActualizarUI()
    {
        if (uIManagerCuatro.instancia != null)
        {
            uIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
        }
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
    private void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.AgarrarAlgodon || gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.LlevarAlgodon || gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PonerAlgodon || gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.AbrirArmario3)
        {
            gameManagerCuatro.instancia.AvanzarPaso();

        }
        if(gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PacienteSilla)
        {
            panel.SetActive(false);
        }
        if(gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.Completado)
        {
           // panel.SetActive(true);
        }
    }
}

