using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarCollider : MonoBehaviour
{
    public Collider miCollider;

    void Start()
    {
        if (miCollider == null)
        {
            miCollider = GetComponent<Collider>(); 
        }
    }

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.AbrirArmario)
        {
            return;
        }
        else {
            miCollider.enabled = false;  // Apagar el collider

        }
    }
}

