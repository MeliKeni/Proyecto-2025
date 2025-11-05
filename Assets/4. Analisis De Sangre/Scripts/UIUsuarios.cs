using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;



public class UIUsuarios : MonoBehaviour
{
    public InputField usuarioInput;
    public InputField passwordInput;
    public Text mensajeTexto;
    private SistemaGuardado sistema;

    public bool logeado = false;
    void Start()
    {
        sistema = FindObjectOfType<SistemaGuardado>();
        //System.Security.Cryptography.Aes
    }
   
    public void Registrar()
    {
        string user = usuarioInput.text;
        string pass = passwordInput.text;

        if (sistema.Registrar(user, pass))
        {
            mensajeTexto.text = "✅ Usuario registrado";
        }
        else
        {
            mensajeTexto.text = "❌ Usuario ya existe";
        }
    }

    public void Login()
    {
        string user = usuarioInput.text;
        string pass = passwordInput.text;

        if (sistema.IniciarSesion(user, pass))
        {
            mensajeTexto.text = "✅ Sesión iniciada";
            // Acá podés cargar otra escena si querés
            logeado = true;

            SceneManager.LoadScene("Escena 4 Analisis de sangre");
        }
        else
        {
            mensajeTexto.text = "❌ Usuario o contraseña incorrectos";
        }
    }

    public void Logout()
    {
        // Marcar como no logueado
        logeado = false;

        // Limpiar campos por si volvemos al login
        if (usuarioInput != null) usuarioInput.text = "";
        if (passwordInput != null) passwordInput.text = "";

        mensajeTexto.text = "👋Sesión cerrada";

    }
}
