using UnityEngine;

public class OrbitPath : MonoBehaviour
{
    public Transform centroOrbita;
    public int segments = 100;
    public float radio;
    public Color color;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = segments + 1;
        lineRenderer.useWorldSpace = false;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float z;
        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radio;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radio;

            lineRenderer.SetPosition(i, new Vector3(x, 0, z));

            angle += (360f / segments);
        }
    }

    void OnMouseEnter()
    {
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
    }

    void OnMouseExit()
    {
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    void OnMouseDown()
    {
        // Lógica para manejar el clic en la órbita
        ClickHandler clickHandler = Camera.main.GetComponent<ClickHandler>();
        if (clickHandler != null)
        {
            clickHandler.HandleOrbitClick(transform.parent);
        }
    }
}

