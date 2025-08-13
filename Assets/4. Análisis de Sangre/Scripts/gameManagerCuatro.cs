using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PasoAnalisisDeSangre // Los pasos a seguir
{
    PacienteSilla,  //0
    AbrirArmario,   //1 
    ColocarGuante,  //2
    JeringaBrazo,   //3
    SacarSangre,    //4
    PonerAlgodon,   //5
    GuardarSangre,  //6
    PonerCurita,    //7
    Completado
}

public class gameManagerCuatro : MonoBehaviour
{
    public static gameManagerCuatro instancia; // Singleton
    public PasoAnalisisDeSangre pasoActual = PasoAnalisisDeSangre.PacienteSilla; // Paso inicial

    private void Awake()
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
        // Si el UI ya existe, actualizamos la instrucción
        if (UIManagerCuatro.instancia != null)
        {
            UIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
        }
        else
        {
            Debug.LogWarning("UIManagerCuatro no está listo aún. Se actualizará más tarde.");
        }
    }

    // Llamado por UIManagerCuatro cuando se inicializa
    public void ActualizarUI()
    {
        if (UIManagerCuatro.instancia != null)
        {
            UIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
        }
    }
}
