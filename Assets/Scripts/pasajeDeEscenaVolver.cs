using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasajeDeEscenaVolver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnBotonClick()
    {
        SceneManager.LoadScene("Escena 1 Inicio");

    }
}

