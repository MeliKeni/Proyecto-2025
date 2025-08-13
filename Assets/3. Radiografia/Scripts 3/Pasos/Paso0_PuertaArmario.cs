using UnityEngine;

public class Paso0_PuertaArmario : MonoBehaviour
{
    public GameObject puerta;
    public float velocidadRotacion = 90f; // grados por segundo
    private bool abrir = false;
    private float anguloRotado = 0f;
    public Camera MyCurrentCam;

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.AbrirArmario){
            return;
        }

        if (!abrir)  //si no esta abieirto 
        {
            // Detectar click y ahi abrir
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = MyCurrentCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null && hit.collider.gameObject == puerta)
                    {
                        abrir = true;
                    }
                }
            }
        }
        else //aca es si abrir es true
        {
            // Rotamos la puerta 90 grados
            if (anguloRotado < 90f)
            {
                float rotacionFrame = velocidadRotacion * Time.deltaTime;
                float rotacionReal = Mathf.Min(rotacionFrame, 90f - anguloRotado);
                puerta.transform.Rotate(Vector3.up, rotacionReal);
                anguloRotado += rotacionReal;

                if (anguloRotado >= 90f) //proximo 
                {
                    GameManager3.instancia.AvanzarPaso();
                }
            }
        }
    }
}
