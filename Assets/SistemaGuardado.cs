using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class UsuarioData
{
    public string usuario;
    public string password;
}

[System.Serializable]
public class ListaUsuarios
{
    public List<UsuarioData> usuarios = new List<UsuarioData>();
}

public class SistemaGuardado : MonoBehaviour
{
    private string rutaArchivo;
    public ListaUsuarios listaUsuarios = new ListaUsuarios();

    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/users.json";
        Debug.Log("Ruta archivo: " + rutaArchivo);
        CargarUsuarios();
    }

    // Registrar usuario nuevo
    public bool Registrar(string user, string pass)
    {
        // Verificar si ya existe
        foreach (var u in listaUsuarios.usuarios)
        {
            if (u.usuario == user)
            {
                Debug.Log("❌ Usuario ya existe");
                return false;
            }
        }

        UsuarioData nuevo = new UsuarioData();
        nuevo.usuario = user;
        nuevo.password = pass;

        listaUsuarios.usuarios.Add(nuevo);
        GuardarUsuarios();

        Debug.Log("✅ Usuario registrado: " + user);
        return true;
    }

    // Login
    public bool IniciarSesion(string user, string pass)
    {
        foreach (var u in listaUsuarios.usuarios)
        {
            if (u.usuario == user && u.password == pass)
            {
                Debug.Log("✅ Login exitoso: " + user);
                return true;
            }
        }

        Debug.Log("❌ Usuario o contraseña incorrectos");
        return false;
    }

    // Guardar JSON
    void GuardarUsuarios()
    {
        string json = JsonUtility.ToJson(listaUsuarios, true);
        File.WriteAllText(rutaArchivo, json);
    }

    // Cargar JSON
    void CargarUsuarios()
    {
        if (File.Exists(rutaArchivo))
        {
            string json = File.ReadAllText(rutaArchivo);
            listaUsuarios = JsonUtility.FromJson<ListaUsuarios>(json);
        }
        else
        {
            GuardarUsuarios(); // crea archivo vacío
        }
    }
}

