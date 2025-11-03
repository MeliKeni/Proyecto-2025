using UnityEngine;
using TMPro;  // Importante
using UnityEngine.UI;

public class uIManagerCuatro : MonoBehaviour
{
    public static uIManagerCuatro instancia;
    [SerializeField] Image[] imagenes;

    public TextMeshProUGUI textoInstruccion;

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
        // Apagamos todas las imágenes
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].enabled = false;
        }

        switch (paso)
        {
            case PasoAnalisisDeSangre.PacienteSilla:
                textoInstruccion.text = "Hace click en el paciente y luego en la silla para indicarle que se siente"; //Dirige al paciente a la silla.
                imagenes[1].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario:
                textoInstruccion.text = ""; //Hace click en el carrito.
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarGuante:
                textoInstruccion.text = "Toca la liga.";
                imagenes[3].enabled = true;
                break;
            case PasoAnalisisDeSangre.ColocarGuante:
                textoInstruccion.text = ""; //Ata la liga alrededor del brazo del paciente.
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario2:
                textoInstruccion.text = ""; //Hace click en el carrito
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlcohol:
                textoInstruccion.text = ""; //Ponele al algodon alcohol
                imagenes[4].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarAlgodon1:
                textoInstruccion.text = ""; //Agarra el algodon 
                imagenes[5].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlgodon1:
                textoInstruccion.text = ""; //Desinfecta el brazo con el algodon
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.TirarAlgodon:
                textoInstruccion.text = ""; //Tira el algodon a la basura
                imagenes[6].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario2_5:
                textoInstruccion.text = ""; //Hace click en el carrito
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarJeringa:
                textoInstruccion.text = ""; //Hace click en la jeringa
                imagenes[8].enabled = true;
                break;
            case PasoAnalisisDeSangre.JeringaBrazo:
                textoInstruccion.text = ""; //Lleva la jeringa al brazo
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.SacarSangre:
                textoInstruccion.text = "Interactuá con la jeringa para seguir el estudio.";
                imagenes[10].enabled = true;
                break;
            case PasoAnalisisDeSangre.SangreSacada:
                textoInstruccion.text = "----------------";
                imagenes[11].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario3:
                textoInstruccion.text = ""; //Hace click en el carrito
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.GuardarSangre:
                textoInstruccion.text = "Colocá la sangre en el recipiente";
                imagenes[12].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario4:
                textoInstruccion.text = ""; //"Hace click en el carrito
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarCurita:
                textoInstruccion.text = ""; //Agarra la curita
                imagenes[13].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerCurita:
                textoInstruccion.text = ""; //Aplicá la curita al brazo del paciente
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.Completado:
                textoInstruccion.text = ""; //Estudio completado. ¡Buen trabajo!
                imagenes[15].enabled = true;
                break;
            default:
                textoInstruccion.text = "";
                break;
        }
    }

    public void ResetUI()
    {
        // Vuelve a buscar el texto en la nueva escena
        textoInstruccion = GameObject.Find("TextoInstruccion").GetComponent<TextMeshProUGUI>();
        textoInstruccion.text = "";
    }
}
