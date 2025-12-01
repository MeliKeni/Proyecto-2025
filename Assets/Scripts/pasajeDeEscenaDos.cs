using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pasajeDeEscenaDos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(null, default, CursorMode.Auto);

    }


    public void OnBotonClick()
    {
        Cursor.SetCursor(null, default, CursorMode.Auto);

        SceneManager.LoadScene("Escena 4 Analisis de sangre 2");

    }
}
