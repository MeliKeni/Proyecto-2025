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
                textoInstruccion.text = "Dirige al paciente a la silla.";
                imagenes[0].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario:
                textoInstruccion.text = "Abrí el armario.";
                imagenes[1].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarGuante:
                textoInstruccion.text = "Toca el guante.";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.ColocarGuante:
                textoInstruccion.text = "Ata el guante alrededor del brazo del paciente.";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.AbrirArmario2:
                textoInstruccion.text = "Abri el armario.";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.AgarrarJeringa:
                textoInstruccion.text = "Hace click en la jeringa";
                imagenes[2].enabled = true;
                break;
            case PasoAnalisisDeSangre.JeringaBrazo:
                textoInstruccion.text = "Arrastra la jeringa al brazo del paciente para extraer la sangre";
                imagenes[3].enabled = true;
                break;
            case PasoAnalisisDeSangre.SacarSangre:
                textoInstruccion.text = "Interactuá con la jeringa para seguir el estudio.";
                imagenes[4].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerAlgodon:
                textoInstruccion.text = "Aplicá algodón en el brazo.";
                imagenes[5].enabled = true;
                break;
            case PasoAnalisisDeSangre.GuardarSangre:
                textoInstruccion.text = "Colocá la sangre en el recipiente";
                imagenes[6].enabled = true;
                break;
            case PasoAnalisisDeSangre.PonerCurita:
                textoInstruccion.text = "Aplicá la curita al brazo del paciente";
                imagenes[7].enabled = true;
                break;
            case PasoAnalisisDeSangre.Completado:
                textoInstruccion.text = "Estudio completado. ¡Buen trabajo!";
                imagenes[8].enabled = true;
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
