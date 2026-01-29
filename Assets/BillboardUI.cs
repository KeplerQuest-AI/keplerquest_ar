using UnityEngine;

[ExecuteAlways]  // Funciona en modo edición y juego
public class AdvancedBillboard : MonoBehaviour
{
    [Header("Configuración de Imagen")]
    public Texture2D imageTexture;  // Textura para asignar
    public Color imageColor = Color.white;  // Color y transparencia

    [Header("Posición")]
    public Vector3 positionOffset = Vector3.zero;
    public bool followCamera = false;
    public float followSmoothness = 5f;

    [Header("Rotación")]
    public Vector3 rotationOffset = Vector3.zero;
    public bool lockXAxis = false;
    public bool lockYAxis = false;
    public bool lockZAxis = false;

    [Header("Escala")]
    public Vector2 baseSize = new Vector2(1, 1);
    public float scaleMultiplier = 1f;
    public bool autoScaleWithDistance = false;
    public float minScale = 0.5f;
    public float maxScale = 2f;

    private Camera mainCamera;
    private Material material;
    private Renderer quadRenderer;

    void Start()
    {
        InitializeComponents();
        UpdateMaterial();
    }

    void InitializeComponents()
    {
        mainCamera = Camera.main;
        
        if (TryGetComponent<Renderer>(out quadRenderer))
        {
            // Crear nuevo material para no afectar otros objetos
            material = new Material(Shader.Find("Unlit/Transparent"));
            quadRenderer.material = material;
        }
        else
        {
            Debug.LogError("No se encontró Renderer en el objeto");
        }
    }

    void Update()
    {
        UpdatePosition();
        UpdateRotation();
        UpdateScale();
    }

    void UpdatePosition()
    {
        if (followCamera && mainCamera != null)
        {
            // Movimiento suave hacia la posición objetivo
            Vector3 targetPos = mainCamera.transform.position + positionOffset;
            transform.position = Vector3.Lerp(transform.position, targetPos, 
                followSmoothness * Time.deltaTime);
        }
    }

    void UpdateRotation()
    {
        if (mainCamera != null)
        {
            // Orientación hacia la cámara con offsets
            Vector3 lookDirection = mainCamera.transform.position - transform.position;
            
            // Bloquear ejes según configuración
            if (lockXAxis) lookDirection.x = 0.001f;
            if (lockYAxis) lookDirection.y = 0.001f;
            if (lockZAxis) lookDirection.z = 0.001f;

            transform.rotation = Quaternion.LookRotation(lookDirection)*Quaternion.Euler(rotationOffset);
        }
    }

    void UpdateScale()
    {
        float finalScale = scaleMultiplier;
        
        if (autoScaleWithDistance && mainCamera != null)
        {
            // Escala proporcional a la distancia
            float distance = Vector3.Distance(transform.position, mainCamera.transform.position);
            finalScale = Mathf.Clamp(distance * 0.1f, minScale, maxScale) * scaleMultiplier;
        }

        transform.localScale = new Vector3(
            baseSize.x * finalScale,
            baseSize.y * finalScale,
            1);
    }

    void UpdateMaterial()
    {
        if (material != null)
        {
            material.mainTexture = imageTexture;
            material.color = imageColor;
        }
    }

    // Método para actualizar la textura en tiempo real
    public void ChangeImage(Texture2D newTexture)
    {
        imageTexture = newTexture;
        UpdateMaterial();
    }

    // Método para actualizar el color en tiempo real
    public void ChangeColor(Color newColor)
    {
        imageColor = newColor;
        UpdateMaterial();
    }

    #if UNITY_EDITOR
    void OnValidate()
    {
        // Actualiza cambios en el editor sin necesidad de entrar en Play Mode
        if (!Application.isPlaying)
        {
            InitializeComponents();
            UpdateMaterial();
        }
    }
    #endif
}