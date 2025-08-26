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
                textoInstruccion.text = "Arrastra la jeringa al brazo del paciente para extraer la sangre";
                break;
            case PasoAnalisisDeSangre.SacarSangre:
                textoInstruccion.text = "Interactuá con la jeringa para seguir el estudio.";
                break;
            case PasoAnalisisDeSangre.PonerAlgodon:
                textoInstruccion.text = "Aplicá algodón en el brazo.";
                break;
            case PasoAnalisisDeSangre.GuardarSangre:
                textoInstruccion.text = "Colocá la sangre en el recipiente";
                break;
            case PasoAnalisisDeSangre.PonerCurita:
                textoInstruccion.text = "Aplicá la curita al brazo del paciente";
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