using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.GameCenter;

public class uIManagerCuatro : MonoBehaviour
{
    public static uIManagerCuatro instancia;

    [SerializeField] private Image[] imagenes;

    public TextMeshProUGUI textoInstruccion;   // Texto principal
    public TextMeshProUGUI textoSecundario;    // Texto secundario
    public Button boton;

    private bool usandoTextoPrincipal = true;
    private PasoAnalisisDeSangre pasoActual;

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
                textoInstruccion.text = "Haz click en el paciente y luego en la silla para indicarle que se siente";
                imagenes[1].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario:
                textoInstruccion.text = "Haz click en el carrito para ir a agarrar cosas";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarGuante:
                textoInstruccion.text = "Haz click en la liga para agarrarla";
                imagenes[3].enabled = true;
                break;
            case PasoAnalisisDeSangre.ColocarGuante:
                textoInstruccion.text = "Haz click en el brazo izquierdo del paciente para atarle la liga";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlcohol:
                textoInstruccion.text = "Haz click en el algodón y luego en el alcohol para mojarlo";
                imagenes[4].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarAlgodon1:
                textoInstruccion.text = "Haz click en el algodón para agarrarlo";
                imagenes[5].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlgodon1:
                textoInstruccion.text = "Haz click en el brazo izquierdo del paciente para desinfectarlo";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.TirarAlgodon:
                textoInstruccion.text = "Haz click en el tacho de basura para tirar el algodón";
                imagenes[6].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarJeringa:
                textoInstruccion.text = "Haz click en la jeringa para agarrarla";
                imagenes[8].enabled = true;
                break;
            case PasoAnalisisDeSangre.JeringaBrazo:
                textoInstruccion.text = "Haz click en el brazo izquierdo del paciente para sacarle sangre";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.SacarSangre:
                textoInstruccion.text = "Interactúa con la jeringa para continuar el estudio";
                imagenes[10].enabled = true;
                break;
            case PasoAnalisisDeSangre.SangreSacada:
                textoInstruccion.text = "----------------";
                imagenes[11].enabled = true;
                break;
            case PasoAnalisisDeSangre.GuardarSangre:
                textoInstruccion.text = "Coloca la sangre en el recipiente";
                imagenes[12].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarCurita:
                textoInstruccion.text = "Haz click en la curita para agarrarla";
                imagenes[13].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerCurita:
                textoInstruccion.text = "Haz click en el brazo izquierdo del paciente para ponerle la curita";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.Completado:
                textoInstruccion.text = "¡Terminamos! Buen trabajo";
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
            case PasoAnalisisDeSangre.PonerAlcohol:
                return "Le ponemos alcohol al algodon para usarlo para desinfectar";
            case PasoAnalisisDeSangre.AgarrarAlgodon1:
                boton.se;
            case PasoAnalisisDeSangre.PonerAlgodon1:
                return "Una vez humedo lo frotamos ";
            case PasoAnalisisDeSangre.TirarAlgodon:
                return "Texto secundario: deposita el algodón usado en la basura correctamente.";
            case PasoAnalisisDeSangre.AgarrarJeringa:
                return "Texto secundario: asegúrate de que la jeringa esté lista y limpia.";
            case PasoAnalisisDeSangre.JeringaBrazo:
                return "Texto secundario: coloca la jeringa suavemente en el brazo del paciente.";
            case PasoAnalisisDeSangre.SacarSangre:
                return "Texto secundario: realiza la extracción con cuidado y atención.";
            case PasoAnalisisDeSangre.SangreSacada:
                return "Texto secundario: verifica que la sangre esté completa y segura.";
            case PasoAnalisisDeSangre.GuardarSangre:
                return "Texto secundario: coloca la sangre en el recipiente adecuado.";
            case PasoAnalisisDeSangre.AgarrarCurita:
                return "Texto secundario: toma la curita sin tocar la parte adhesiva.";
            case PasoAnalisisDeSangre.PonerCurita:
                return "Texto secundario: coloca la curita sobre la zona pinchada con cuidado.";
            case PasoAnalisisDeSangre.Completado:
                return "Texto secundario: el procedimiento ha finalizado correctamente.";
            default:
                return "";
        }
    }

    public void ResetUI()
    {
        textoInstruccion = GameObject.Find("TextoInstruccion").GetComponent<TextMeshProUGUI>();
        textoInstruccion.text = "";
    }
}
