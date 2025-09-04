using System.Collections.Generic;
using UnityEngine;

public class CursorTrail : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private List<Vector3> points;
    private Plane movementPlane;
    public GameManager3 gameManager;

    void Start()
    {
        points = new List<Vector3>();
        movementPlane = new Plane(Vector3.up, Vector3.zero);
    }

    void Update()
    {
        if (GameManager3.instancia.pasoActual != PasoRadiografia.GestoComputadora)
        {
            points.Clear();
            lineRenderer.positionCount = 0;
            return;
        }
        if (Input.GetMouseButton(0)) //no tiene ni down ni up para q sea tipo un stay
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float enter;

            if (movementPlane.Raycast(ray, out enter))
            {
                Vector3 worldPos = ray.GetPoint(enter);

                // Agrego punto solo si está lo suficientemente lejos del anterior
                if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], worldPos) > 0.1f)
                {
                    points.Add(worldPos);
                    lineRenderer.positionCount = points.Count;
                    lineRenderer.SetPositions(points.ToArray());
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            points.Clear();
            lineRenderer.positionCount = 0;
        }
    }
}
