using UnityEngine;
using TMPro;  // Importante

public class uIManagerCuatro : MonoBehaviour
{
    public static uIManagerCuatro instancia;

    public TextMeshProUGUI textoInstruccion;

    private void Awake()
    {
        if (instancia == null) //solo va a haber un uimanger
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActualizarInstruccion(PasoAnalisisDeSangre paso)
    {
        switch (paso)
        {
            case PasoAnalisisDeSangre.PacienteSilla:
                textoInstruccion.text = "Dirige al paciente a la silla.";
                break;
            case PasoAnalisisDeSangre.AbrirArmario:
                textoInstruccion.text = "Abrí el armario.";
                break;
            case PasoAnalisisDeSangre.ColocarGuante:
                textoInstruccion.text = "Ata el guante alrededor del brazo del paciente.";
                break;
            case PasoAnalisisDeSangre.JeringaBrazo:
                textoInstruccion.text = "Tocá el botón para iniciar la radiografía.";
                break;
            case PasoAnalisisDeSangre.SacarSangre:
                textoInstruccion.text = "Interactuá con la computadora para seguir el estudio.";
                break;
            case PasoAnalisisDeSangre.PonerAlgodon:
                textoInstruccion.text = "Esperá mientras se realiza el escaneo.";
                break;
            case PasoAnalisisDeSangre.GuardarSangre:
                textoInstruccion.text = "Retirá el chaleco del paciente.";
                break;
            case PasoAnalisisDeSangre.PonerCurita:
                textoInstruccion.text = "Imprimí el estudio.";
                break;
            case PasoAnalisisDeSangre.Completado:
                textoInstruccion.text = "Estudio completado. ¡Buen trabajo!";
                break;
            default:
                textoInstruccion.text = "";
                break;
        }
    }
}
