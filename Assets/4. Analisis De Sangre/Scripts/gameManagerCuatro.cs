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
    public Animator PanelController;
    public GameObject jeringa;
    public float tiempoCooldown = 0.2f;
    private bool puedeAvanzar = true;


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

    public void AvanzarPaso()
    {
        // 🔥 ANTI–DOBLE–CLICK
        if (!puedeAvanzar) return;       // si está bloqueado, no avanza
        puedeAvanzar = false;            // bloquear avances
        StartCoroutine(ReactivarAvance()); // iniciar cooldown

        // Si ya está completado, no avanza más
        if (pasoActual == PasoAnalisisDeSangre.Completado)
        {
            Debug.Log("El estudio ya está completado");
            return;
        }

        // Mostrar comentarista (como tenías)
        uIManagerCuatro.instancia.MostrarComentarista(3f);

        // Avanzar de paso
        pasoActual++;
        Debug.Log("Avanzando al paso: " + pasoActual);

        // Actualizar UI
        uIManagerCuatro.instancia.ActualizarInstruccion(pasoActual);
    }
    IEnumerator ReactivarAvance()
    {
        yield return new WaitForSeconds(tiempoCooldown);
        puedeAvanzar = true;
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
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PacienteSilla)
        {
            PanelController.SetBool("Mostrar", false);
            panel.SetActive(false);

        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.Completado)
        {
            panel.SetActive(true);
            PanelController.SetBool("Mostrar", true);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.GuardarSangre)
        {
            jeringa.SetActive(false);
        }
    }
}

