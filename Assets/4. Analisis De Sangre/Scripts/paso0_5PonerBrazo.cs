using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso0_5PonerBrazo : MonoBehaviour
{
    public GameObject PacienteSentador;
    public GameObject PacienteBrazo;    
    public Animator anim;

    private bool yaEjecutado = false;   // <--- evita que corra mil veces

    void Start()
    {
        PacienteSentador.SetActive(true);
        PacienteBrazo.SetActive(false);
        anim.SetBool("MoverBrazo", false);
    }

    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.BrazoMovimiento)
        {
            return;
        }

        if (yaEjecutado) return;  // <--- frena repeticiones

        yaEjecutado = true;

        // Ejecuta la lógica una sola vez
        PacienteSentador.SetActive(false);
        PacienteBrazo.SetActive(true);
        anim.SetBool("MoverBrazo", true);

        StartCoroutine(Esperar());
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(3f);
        gameManagerCuatro.instancia.AvanzarPaso();
    }
}
