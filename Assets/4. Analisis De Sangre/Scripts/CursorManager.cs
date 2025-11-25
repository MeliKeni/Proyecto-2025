    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Imagenes")]
    public Texture2D imagenCursor2;
    public Texture2D imagenGuante;
    public Texture2D imagenJeringa;
    public Texture2D imagenAlgodon;
    public Texture2D imagenCurita;
    public Texture2D hoverMano;
    public Vector2 hotspotDefault = Vector2.zero;
    public Vector2 hotspotGuante;
    public Vector2 hotspotJeringa;
    public Vector2 hotspotAlgodon;
    public Vector2 hotspotCurita;
    public Vector2 hotspotMano;
    

    [Header("scripts")]
    public gameManagerCuatro gameManager;
    public paso1_PuertaArmario paso1script;
    public paso2_ColocarGuante paso2script;
    public paso8_AgarrarGuante paso8script;
    public Paso2_1_2_AgarrarAlgodon1 paso2_1_2script;
    public cameraController camaraController;

    [Header("Objetos")]
    public GameObject guante;
    public GameObject jeringa;
    public GameObject algodon;
    public GameObject curita;

    public Camera MyCurrentCam;


    void Start()
    {
        hotspotGuante = new Vector2(imagenGuante.width / 2f, imagenGuante.height / 2f);
        hotspotJeringa = new Vector2(0, imagenJeringa.height); //abajo izquierda
        hotspotAlgodon = new Vector2(imagenAlgodon.width / 2f, imagenAlgodon.height / 2f);
        hotspotCurita = new Vector2(imagenCurita.width / 2f, imagenCurita.height / 2f);
        hotspotMano = new Vector2(hoverMano.width / 2f, hoverMano.height / 2f);
        Cursor.SetCursor(null, hotspotDefault, CursorMode.Auto); 
        //La funcion SetCursor,tiene 3 parametros necesarios,
        //la imagen que voy a usar, pongo null si es la default
        //donde va a ser el lugar de interaccion, donde marca el click,
        //generalmente se usa el 0,0 que es la esquina superior izquierda, para que sea el medio hacemos lo de arriba de poner la altura y el ancho sobre 2 de la imagen,
        //y despues esta cursor mode que es algo que no voy a tocar y pones auto y unity te lo resuelve, es para animaciones mas avanzadas
        
        guante.SetActive(true);
        jeringa.SetActive(true);
        algodon.SetActive(true);
        curita.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (paso8script.cursorGuante)
        {

            Cursor.SetCursor(imagenGuante, hotspotGuante, CursorMode.Auto);
            guante.SetActive(false);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.AbrirArmario2)
        {

            Cursor.SetCursor(null, default, CursorMode.Auto);
            paso8script.cursorGuante = false;
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.SacarSangre)
        {

            Cursor.SetCursor(null, default, CursorMode.Auto);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.JeringaBrazo)
        {

            Cursor.SetCursor(imagenJeringa, hotspotJeringa, CursorMode.Auto);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.AbrirArmario3)
        {
            Cursor.SetCursor(null, default, CursorMode.Auto);
            camaraController.cursorJeringa = false;
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PonerAlgodon1)
        {
            Cursor.SetCursor(imagenAlgodon, hotspotAlgodon, CursorMode.Auto);
            algodon.SetActive(false);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.AbrirArmario2_5)
        {

            Cursor.SetCursor(null, default, CursorMode.Auto);

        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.AbrirArmario4)
        {
            Cursor.SetCursor(null, default, CursorMode.Auto);
            camaraController.cursorJeringa = false;

        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.PonerCurita)
        {
            Cursor.SetCursor(imagenCurita, hotspotCurita, CursorMode.Auto);
            curita.SetActive(false);
        }
        if (gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.Completado)
        {
            Cursor.SetCursor(null, default, CursorMode.Auto);

        }
      
        

        /*Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            string tagName = hit.collider.tag;

            if (tagName != "Untagged")
            {
                Cursor.SetCursor(hoverMano, hotspotMano, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, default, CursorMode.Auto);
            }
        } */

    }

}
