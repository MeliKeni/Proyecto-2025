using UnityEngine;
using TMPro;  // Importante

public class UIManager3 : MonoBehaviour
{
    public static UIManager3 instancia;

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

    public void ActualizarInstruccion(PasoRadiografia paso)
    {
        switch (paso)
        {
            case PasoRadiografia.PacienteMaquina:
                textoInstruccion.text = "Arrastrá al paciente a la máquina.";
                break;
            case PasoRadiografia.AbrirArmario:
                textoInstruccion.text = "Abrí el armario.";
                break;
            case PasoRadiografia.ColocarChaleco:
                textoInstruccion.text = "Colocá el chaleco al paciente.";
                break;
            case PasoRadiografia.IniciarRadiografia:
                textoInstruccion.text = "Tocá el botón para iniciar la radiografía.";
                break;
            case PasoRadiografia.GestoComputadora:
                textoInstruccion.text = "Interactuá con la computadora para seguir el estudio.";
                break;
            case PasoRadiografia.Escaneo:
                textoInstruccion.text = "Esperá mientras se realiza el escaneo.";
                break;
            case PasoRadiografia.RetirarChaleco:
                textoInstruccion.text = "Retirá el chaleco del paciente.";
                break;
            case PasoRadiografia.ImprimirEstudio:
                textoInstruccion.text = "Imprimí el estudio.";
                break;
            case PasoRadiografia.EntregarSobre:
                textoInstruccion.text = "Entregá el estudio en un sobre.";
                break;
            case PasoRadiografia.Completado:
                textoInstruccion.text = "Estudio completado. ¡Buen trabajo!";
                break;
            default:
                textoInstruccion.text = "";
                break;
        }
    }
}
