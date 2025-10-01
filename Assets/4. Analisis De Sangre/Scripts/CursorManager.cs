using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D imagenCursor2;
    public Vector2 hotspotDefault = Vector2.zero;
    public Vector2 hotspot2;

    void Start()
    {
        hotspot2 = new Vector2(imagenCursor2.width / 2f, imagenCursor2.height / 2f);
        Cursor.SetCursor(null, hotspotDefault, CursorMode.Auto); 
        //La funcion SetCursor,tiene 3 parametros necesarios,
        //la imagen que voy a usar, pongo null si es la default
        //donde va a ser el lugar de interaccion, donde marca el click,
        //generalmente se usa el 0,0 que es la esquina superior izquierda, para que sea el medio hacemos lo de arriba de poner la altura y el ancho sobre 2 de la imagen,
        //y despues esta cursor mode que es algo que no voy a tocar y pones auto y unity te lo resuelve, es para animaciones mas avanzadas

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Cursor.SetCursor(imagenCursor2, hotspot2, CursorMode.Auto);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cursor.SetCursor(null, hotspotDefault, CursorMode.Auto);
        }
    }
}
