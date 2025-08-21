using UnityEngine;
using TMPro;

public class UIManager3 : MonoBehaviour
{
    public static UIManager3 instancia;

    public TextMeshProUGUI textoInstruccion;

    private void Awake()
    {
        // Singleton simple
        if (instancia == null)
        {
            instancia = this;
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
            case PasoRadiografia.SalirDeMaquina:
                textoInstruccion.text = "Hace click en cualquier lado para avisarle al paciente que ya puede salir";
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
    public void ResetUI()
    {
        // Vuelve a buscar el texto en la nueva escena
        textoInstruccion = GameObject.Find("TextoInstruccion").GetComponent<TextMeshProUGUI>();
        textoInstruccion.text = "";
    }
}
