using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasajeDeEscenaUno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnBotonClick()
    {
        SceneManager.LoadScene("Escena 2 Elección de Estudios");

    }
    void Update()
    {

    }
}
