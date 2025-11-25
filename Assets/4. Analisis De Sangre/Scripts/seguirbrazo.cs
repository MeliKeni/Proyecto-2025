using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguirbrazo : MonoBehaviour
{
    public Transform punta;        // Lo que se va a mover
    public Transform pinchazoTR;   // Objetivo
    public float velocidad = 5f;

    [Header("Arco")]
    public float curvaLateral = 0.2f;  // Ajustá para más/menos arco
    public GameObject modelo;
    private bool entrando = true;
    private bool esperando = false;
    private bool saliendo = false;

    private float tiempoEspera = 3f;
    private float timer = 0f;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = punta.position;
    }

    void Update()
    { 
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.JeringaBrazo)
        {
            modelo.SetActive(false);
            return;
        } else {
            modelo.SetActive(true);
            MoverConArco();
        } 

     

      /*  else if (saliendo)
            SalirConArco();*/
    }

    // ---------------------------------------
    // 1) ENTRA HACIA EL PINCHAZO (con arco)
    // ---------------------------------------
    void MoverConArco()
    {
        Vector3 dir = (pinchazoTR.position - punta.position).normalized;

        // Leve arco lateral
        Vector3 inclinacion = Vector3.Cross(dir, Vector3.up).normalized * curvaLateral;
        Vector3 dirCurvada = (dir + inclinacion).normalized;

        punta.position = Vector3.Lerp(
            punta.position,
            punta.position + dirCurvada,
            Time.deltaTime * velocidad
        );

        // ¿Llegó?
        if (Vector3.Distance(punta.position, pinchazoTR.position) < 0.01f)
        {
            entrando = false;
            esperando = true;
            timer = 0f;
        }
    } 

    // ---------------------------------------
    // 2) ESPERA 3 SEGUNDOS
    // ---------------------------------------
    void Esperar()
    {
        timer += Time.deltaTime;

        if (timer >= tiempoEspera)
        {
            esperando = false;
            saliendo = true;
        }
    }
/*
    // ---------------------------------------
    // 3) SALE CON EL MISMO ARCO (invertido)
    // ---------------------------------------
    void SalirConArco()
    {
        Vector3 dir = (posicionInicial - punta.position).normalized;
        Vector3 inclinacion = Vector3.Cross(dir, Vector3.up).normalized * curvaLateral;
        Vector3 dirCurvada = (dir + inclinacion).normalized;

        punta.position = Vector3.Lerp(
            punta.position,
            punta.position + dirCurvada,
            Time.deltaTime * velocidad
        );

        // ¿Llegó a la posición inicial?
        if (Vector3.Distance(punta.position, posicionInicial) < 0.02f)
        {
            Destroy(gameObject);
        }
    }*/
}
