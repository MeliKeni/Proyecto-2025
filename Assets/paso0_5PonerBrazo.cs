using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso0_5PonerBrazo : MonoBehaviour
{
    public  GameObject PacienteSentador;
    public GameObject PacienteBrazo;    
        public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        PacienteSentador.SetActive(true);
        PacienteBrazo.SetActive(false);
        anim.SetBool("MoverBrazo", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.BrazoMovimiento)
        {
            return;
        }else{
             PacienteSentador.SetActive(false);
        PacienteBrazo.SetActive(true);
        anim.SetBool("MoverBrazo", true);

        }

    }
}
