using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogeoUI2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelgeneral;
    public GameObject panellogeo;

    public UIUsuarios UIUsuariosScript;


    void Start()
    {
        panelgeneral.SetActive(true);
        panellogeo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    public void CambiarPanel()
    {
        panelgeneral.SetActive(!panelgeneral.activeSelf);
        panellogeo.SetActive(!panellogeo.activeSelf);
    }
}
