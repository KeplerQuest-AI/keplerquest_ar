using UnityEngine;

[RequireComponent(typeof(EllipticalOrbit))]
public class KeplerOrbitVisualizer : MonoBehaviour
{
    [Header("Visualización")]
    public GameObject areaFill;           // Objeto para el área barrida (Mesh)
    public Color areaColor = new Color(0, 1, 0, 0.3f); // Verde transparente

    // Puntos clave de la órbita en radianes
    private readonly float pointA = 0f;
    private readonly float pointB = Mathf.PI * 0.5f;
    private readonly float pointC = Mathf.PI * 41/36f;
    private readonly float pointD = Mathf.PI * 49/36f;

    private EllipticalOrbit orbit;
    private Material areaMaterial;

    void Start()
    {
        orbit = GetComponent<EllipticalOrbit>();
        InitializeAreaVisualization();
    }

    void InitializeAreaVisualization()
    {
        areaMaterial = new Material(Shader.Find("Sprites/Default"));
        areaMaterial.color = areaColor;
        areaFill.GetComponent<MeshRenderer>().material = areaMaterial;
        areaFill.SetActive(false);
    }

    void Update()
    {
        UpdateAreaVisualization();
    }

    void UpdateAreaVisualization()
    {
        float currentAngle = NormalizeAngle(orbit.GetCurrentAngle());

        bool isInAreaAB = currentAngle >= pointA && currentAngle <= pointB;
        bool isInAreaCD = currentAngle >= pointC && currentAngle <= pointD;

        if (isInAreaAB || isInAreaCD)
        {
            float startAngle = isInAreaAB ? pointA : pointC;
            float endAngle = isInAreaAB ? pointB : pointD;

            float progress = Mathf.InverseLerp(startAngle, endAngle, currentAngle);
            UpdateAreaFill(startAngle, currentAngle, progress);
        }
        else
        {
            areaFill.SetActive(false);
        }
    }

    void UpdateAreaFill(float startAngle, float currentAngle, float progress)
    {
        areaFill.SetActive(true);
        Mesh mesh = new Mesh();

        int segments = Mathf.Max(2, Mathf.CeilToInt(progress * 40)); // Aumentamos la resolución

        Vector3[] vertices = new Vector3[segments + 2];
        int[] triangles = new int[segments * 3];

        // ✅ CENTRAMOS el vértice en el foco real de la elipse (posición del Sol)
        Vector3 focus = orbit.sun.position;
        vertices[0] = areaFill.transform.InverseTransformPoint(focus); // Convertimos a espacio local del mesh

        // Creamos los vértices del arco en la elipse
        for (int i = 0; i <= segments; i++)
        {
            float theta = Mathf.Lerp(startAngle, currentAngle, i / (float)segments);
            Vector3 worldPoint = orbit.GetOrbitPoint(theta);
            vertices[i + 1] = areaFill.transform.InverseTransformPoint(worldPoint);
        }

        // Creamos triángulos tipo "fan"
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;         // centro (foco)
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        areaFill.GetComponent<MeshFilter>().mesh = mesh;
    }

    // 🔁 Normaliza ángulos entre 0 y 2π para evitar errores entre 0 y 2π/360°
    float NormalizeAngle(float angle)
    {
        angle %= 2 * Mathf.PI;
        if (angle < 0) angle += 2 * Mathf.PI;
        return angle;
    }
}
