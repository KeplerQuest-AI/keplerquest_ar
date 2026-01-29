using UnityEngine;

public class EllipticalOrbit : MonoBehaviour
{
    public Transform sun;               // Objeto Sol (foco principal)
    public float a = 5f;               // Semi-eje mayor
    public float e = 0.7f;             // Excentricidad (0 = circular)
    public float orbitSpeed = 0.5f;     // Velocidad base
    
    private float b;                    // Semi-eje menor
    private float c;                    // Distancia focal
    private float angle;                // Ángulo actual
    private float currentSpeed;         // Velocidad actual

    void Start()
    {
        CalculateOrbitParameters();
        UpdatePlanetPosition();
    }

    void Update()
    {
        // Ley de Kepler: velocidad varía según distancia
        float distance = Vector3.Distance(transform.position, sun.position);
        currentSpeed = orbitSpeed * (1f / (distance * distance)) * Time.deltaTime;
        angle += currentSpeed;
        
        UpdatePlanetPosition();
    }

    void CalculateOrbitParameters()
    {
        c = a * e;                     // Distancia del centro al foco
        b = a * Mathf.Sqrt(1f - e * e); // Semi-eje menor
    }

    void UpdatePlanetPosition()
    {
        // Ecuación paramétrica de la elipse
        float x = a * Mathf.Cos(angle) - c;
        float z = b * Mathf.Sin(angle);
        
        // Posición relativa al Sol
        transform.position = sun.position + new Vector3(x, 0, z);
    }

    // Método público para obtener puntos de la órbita
    public Vector3 GetOrbitPoint(float theta)
    {
        float x = a * Mathf.Cos(theta) - c;
        float z = b * Mathf.Sin(theta);
        return sun.position + new Vector3(x, 0, z);
    }

    // Método público para obtener el ángulo actual
    public float GetCurrentAngle()
    {
        return angle;
    }
}