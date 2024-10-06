using UnityEngine;

public class OrbitPath : MonoBehaviour
{
    public Transform centroOrbita;
    public Color color;
    public float lineWidth = 0.03f; // Ajusta este valor para cambiar la anchura de la línea
    private LineRenderer lineRenderer;
    private int segments = 1000; // Número de segmentos para la órbita

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        DrawOrbit();
    }

    void DrawOrbit()
    {
        lineRenderer.positionCount = segments + 1;
        float angle = 0f;
        float radius = Vector3.Distance(transform.position, centroOrbita.position);

        for (int i = 0; i <= segments; i++)
        {
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            lineRenderer.SetPosition(i, new Vector3(x, 0, z) + centroOrbita.position);
            angle += 360f / segments;
        }
    }

    public void HighlightOrbit(bool highlight)
    {
        if (highlight)
        {
            lineRenderer.startColor = Color.yellow;
            lineRenderer.endColor = Color.yellow;
        }
        else
        {
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
        }
    }
}








