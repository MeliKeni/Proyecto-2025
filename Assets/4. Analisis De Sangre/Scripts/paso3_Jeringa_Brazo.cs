using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paso3_Jeringa_Brazo : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject jeringa;
    [Tooltip("Si querés, podés dejar esto en null y buscar el paciente por tag cuando haga overlap")]
    public GameObject paciente;

    [Header("Ajustes de colocación")]
    public float alturaSobrePaciente = 1.0f; // cuan arriba va a estar del paciente, 
    public float overlapRadius = 0.6f;       // cucando ya detecta la colision
    public bool autoSoltarAlTocar = true;    // si true, suelta automáticamente al tocar paciente, si false, hay que  soltar mouse

    bool arrastrando = false;
    float zFija; // para que no se mueva en el eje z
    private GameObject pacienteEnColision = null;  // esta en colision con el paciente
    public Camera MyCurrentCam;
    public paso8_AgarrarGuante paso8script;
    public GameObject Jeringa;
    public uIManagerCuatro uiManager;
    
    void Start()
    {
        Jeringa.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerCuatro.instancia.pasoActual != PasoAnalisisDeSangre.JeringaBrazo)
        {
            return; // anulamos todo si no estamos en el paso que hay que estar
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit h;
            if (Physics.Raycast(r, out h))
            {
                if (h.collider.CompareTag("Brazo"))
                {

                    Jeringa.SetActive(true);
                    gameManagerCuatro.instancia.AvanzarPaso();
                }
            }
        }
    }
}
