using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class uIManagerCuatro : MonoBehaviour
{
    public static uIManagerCuatro instancia;

    [SerializeField] private Image[] imagenes;
    [SerializeField] Text[] indicaciones;

    public TextMeshProUGUI textoInstruccion;   // Texto principal
    public TextMeshProUGUI textoSecundario;    // Texto secundario
    public TextMeshProUGUI textoIndicaciones;
    public TextMeshProUGUI pasoNumero;
    public GameObject comentarista;
    public paso2_1_1_PonerAlcohol paso2_1_1Script;

    public Button boton;

    private bool usandoTextoPrincipal = true;
    private PasoAnalisisDeSangre pasoActual;

    public Camera MyCurrentCam;


    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        comentarista.SetActive(false);
    }

    public void ActualizarInstruccion(PasoAnalisisDeSangre paso)
    {
        pasoActual = paso;

        // Apagamos todas las imágenes
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].enabled = false;
        }

        // Siempre mostrar texto principal al actualizar
        usandoTextoPrincipal = true;
        textoInstruccion.enabled = true;
        textoSecundario.enabled = false;

        // Textos principales
        switch (paso)
        {
            case PasoAnalisisDeSangre.PacienteSilla:
                textoInstruccion.text = "Haz click en el paciente para indicarle que se siente";
                pasoNumero.text = "Paso 1";
                imagenes[1].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario:
                textoInstruccion.text = "Haz click en el carrito para ir a agarrar cosas";
                pasoNumero.text = "Paso 2";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario2:
                textoInstruccion.text = "Haz click en el carrito para ir a agarrar cosas";
                pasoNumero.text = "Paso 5";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario2_5:
                textoInstruccion.text = "Haz click en el carrito para ir a agarrar cosas";
                pasoNumero.text = "Paso 10";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario3:
                textoInstruccion.text = "Haz click en el carrito para ir a agarrar cosas";
                pasoNumero.text = "Paso 16";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario4:
                textoInstruccion.text = "Haz click en el carrito para ir a agarrar cosas";
                pasoNumero.text = "Paso 16";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarGuante:
                textoInstruccion.text = "Haz click en la liga para agarrarla";
                pasoNumero.text = "Paso 3";
                imagenes[3].enabled = true;
                break;
            case PasoAnalisisDeSangre.ColocarGuante:
                textoInstruccion.text = "Haz click en el brazo derecho del paciente para atarle la liga";
                pasoNumero.text = "Paso 4";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlcohol:
                textoInstruccion.text = "Haz click en el algodón y luego en el alcohol para mojarlo";
                pasoNumero.text = "Paso 6";
                imagenes[4].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarAlgodon1:
                textoInstruccion.text = "Haz click en el algodón para agarrarlo";
                pasoNumero.text = "Paso 7";
                imagenes[5].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlgodon1:
                textoInstruccion.text = "Mantene el click y move el mouse en circulos para frotarle el algodon";
                pasoNumero.text = "Paso 8";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.TirarAlgodon:
                textoInstruccion.text = "Haz click en el tacho de basura para tirar el algodón";
                pasoNumero.text = "Paso 9";
                imagenes[6].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarJeringa:
                textoInstruccion.text = "Haz click en la jeringa para agarrarla";
                pasoNumero.text = "Paso 11";
                imagenes[8].enabled = true;
                break;
            case PasoAnalisisDeSangre.JeringaBrazo:
                textoInstruccion.text = "Haz click en el brazo derecho del paciente para sacarle sangre";
                pasoNumero.text = "Paso 12";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.SacarSangre:
                textoInstruccion.text = "Interactúa con la jeringa para continuar el estudio";
                pasoNumero.text = "Paso 13";
                imagenes[10].enabled = true;
                break;
            case PasoAnalisisDeSangre.SangreSacada:
                textoInstruccion.text = "Hace click en la jeringa para agarrarla";
                pasoNumero.text = "Paso 14";
                imagenes[10].enabled = true;
                break;
            case PasoAnalisisDeSangre.GuardarSangre:
                textoInstruccion.text = "Coloca la sangre en el recipiente";
                pasoNumero.text = "Paso 15";
                imagenes[15].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarCurita:
                textoInstruccion.text = "Haz click en la curita para agarrarla";
                pasoNumero.text = "Paso 17";
                imagenes[13].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerCurita:
                textoInstruccion.text = "Haz click en el brazo derecho del paciente para ponerle la curita";
                pasoNumero.text = "Paso 18";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.Completado:
                textoInstruccion.text = "¡Terminamos! Buen trabajo";
                pasoNumero.text = "Paso 19";
                imagenes[15].enabled = true;
                break;
            default:
                textoInstruccion.text = "";
                break;
        }
    }

    // Alterna entre principal y secundaria
    public void CambiarTextoLista()
    {
        usandoTextoPrincipal = !usandoTextoPrincipal;

        if (usandoTextoPrincipal)
        {
            textoInstruccion.enabled = true;
            textoSecundario.enabled = false;
        }
        else
        {
            textoInstruccion.enabled = false;
            textoSecundario.enabled = true;

            textoSecundario.text = ObtenerTextoSecundario(pasoActual);
        }
    }

    // Textos secundarios definidos en código (igual que la primera lista)
    private string ObtenerTextoSecundario(PasoAnalisisDeSangre paso)
    {
        switch (paso)
        {
            case PasoAnalisisDeSangre.PacienteSilla:
                return "Se saca sangre sentados para estar lo mas comodos posible";
            case PasoAnalisisDeSangre.AbrirArmario:
                return "En el carrito guardamos todo lo necesario para el procedimiento";
            case PasoAnalisisDeSangre.AgarrarGuante:
                return "Esta es un elastico y se ata en el brazo";
            case PasoAnalisisDeSangre.ColocarGuante:
                return "Se ata en el brazo para que se marquen las venas y poder sacar sangre mas facil";
            case PasoAnalisisDeSangre.AbrirArmario2:
                return "En el carrito guardamos todo lo necesario para el procedimiento";
            case PasoAnalisisDeSangre.AbrirArmario2_5:
                return "En el carrito guardamos todo lo necesario para el procedimiento";
            case PasoAnalisisDeSangre.AbrirArmario3:
                return "En el carrito guardamos todo lo necesario para el procedimiento";
            case PasoAnalisisDeSangre.AbrirArmario4:
                return "En el carrito guardamos todo lo necesario para el procedimiento";
            case PasoAnalisisDeSangre.PonerAlcohol:
                return "Le ponemos alcohol al algodon para usarlo para desinfectar";
            case PasoAnalisisDeSangre.AgarrarAlgodon1:
                return "Le ponemos alcohol al algodon para usarlo para desinfectar"; //
            case PasoAnalisisDeSangre.PonerAlgodon1:
                return "Una vez humedo lo frotamos en el brazo para limpiarlo y evitar infecciones ";
            case PasoAnalisisDeSangre.TirarAlgodon:
                return "Tiramos el algodon que nos quedo al tacho de basura"; //
            case PasoAnalisisDeSangre.AgarrarJeringa:
                return "Hoy en dia tambien se puede hacer con una maquina"; //PONER ALGO
            case PasoAnalisisDeSangre.JeringaBrazo:
                return "Colocamos la jeringa en el brazo, tranquilo que duele poquito!"; //
            case PasoAnalisisDeSangre.SacarSangre:
                return "Esperamos unos segundos mientras sacamos la sangre";
            case PasoAnalisisDeSangre.SangreSacada:
                return "Rapido! Guardemos la sangre!";
            case PasoAnalisisDeSangre.GuardarSangre:
                return "Guardamos la sangre en frascos para luego poder analizarla"; //
            case PasoAnalisisDeSangre.AgarrarCurita:
                return "La curita sirve para tapar la herida, puede ser de personajes animados!";
            case PasoAnalisisDeSangre.PonerCurita:
                return "En unos dias se va a despegar y podes cambiarla por una nueva!";
            case PasoAnalisisDeSangre.Completado:
                return "Felicidades! Estudio terminado";
            default:
                return "";
        }
    }

    public void ResetUI()
    {
        textoInstruccion = GameObject.Find("TextoInstruccion").GetComponent<TextMeshProUGUI>();
        textoInstruccion.text = "";
    }
    float timer;
    public bool avanzarTag;
    public int numeroTag;
    
string ObtenerTagParaPaso(PasoAnalisisDeSangre paso)
{   
    switch (paso)
    {
        case PasoAnalisisDeSangre.PacienteSilla:
            return "Paciente";         
        case PasoAnalisisDeSangre.AbrirArmario:
            return "Armario";
        case PasoAnalisisDeSangre.AgarrarGuante:
            return "Guante";
        case PasoAnalisisDeSangre.ColocarGuante:
            return "Brazo";
        case PasoAnalisisDeSangre.AbrirArmario2:
            return "Armario";
        case PasoAnalisisDeSangre.PonerAlcohol:
            if(paso2_1_1Script.algodonParaAlcoholizar==true){
                return "Botella";
            }
            else{
                return "Algodon";
            }
        case PasoAnalisisDeSangre.AgarrarAlgodon1:
            return "Algodon";
        case PasoAnalisisDeSangre.PonerAlgodon1:
            return "Brazo";
        case PasoAnalisisDeSangre.TirarAlgodon:
            return "Tacho";
        case PasoAnalisisDeSangre.AbrirArmario2_5:
            return "Armario";
        case PasoAnalisisDeSangre.AgarrarJeringa:
            return "Jeringa";
        case PasoAnalisisDeSangre.JeringaBrazo:
            return "Brazo";
        case PasoAnalisisDeSangre.SacarSangre:
            return "Jeringa";
        case PasoAnalisisDeSangre.SangreSacada:
            return "Jeringa";
        case PasoAnalisisDeSangre.AbrirArmario3:
            return "Armario";
        case PasoAnalisisDeSangre.GuardarSangre:
            return "Jeringa";
        case PasoAnalisisDeSangre.AbrirArmario4:
            return "Armario";
        case PasoAnalisisDeSangre.AgarrarCurita:
            return "Curita";
        case PasoAnalisisDeSangre.PonerCurita:
            return "Brazo";     
    }
                return "default";
}

    public void MostrarComentarista(float duracion)
    {
        textoIndicaciones.text = "ESTO ES UNA PRUEBA"; // TEST

        comentarista.SetActive(true);
        timer = duracion;
    }
    void Update(){

        if (comentarista.activeSelf)
        {
            textoIndicaciones.text = ObtenerTextoSecundario(pasoActual);

            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                comentarista.SetActive(false);
            }
        }


        if(gameManagerCuatro.instancia.pasoActual == PasoAnalisisDeSangre.TirarAlgodon)
        {
            gameManagerCuatro.instancia.TagDeseada = "Tacho";
        }
        
    }
}
