using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawOrbit : MonoBehaviour
{
    public EllipticalOrbit planetOrbit; // Referencia al script de órbita
    public int segments = 100;          // Segmentos para dibujar
    public float width = 0.1f;         // Ancho de la línea
    public Color orbitColor = Color.cyan;

    private LineRenderer lineRenderer;

    void Start()
    {
        InitializeRenderer();
        DrawEllipse();
    }

    void InitializeRenderer()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = true;
        lineRenderer.widthMultiplier = width;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = orbitColor;
    }

    void DrawEllipse()
    {
        if (!planetOrbit || !planetOrbit.sun) return;

        lineRenderer.positionCount = segments + 1;
        Vector3[] points = new Vector3[segments + 1];

        for (int i = 0; i <= segments; i++)
        {
            float angle = 2f * Mathf.PI * i / segments;
            points[i] = planetOrbit.GetOrbitPoint(angle);
        }

        lineRenderer.SetPositions(points);
    }

    void Update()
    {
        // Actualizar dinámicamente si es necesario
        if (planetOrbit && planetOrbit.sun)
        {
            DrawEllipse();
        }
    }
}