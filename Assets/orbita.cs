using UnityEngine;

public class Orbita : MonoBehaviour
{
    public Transform centroOrbita; // El objeto alrededor del cual orbita
    public float velocidadOrbita; // Velocidad de la órbita
    public float velocidadRotacion; // Velocidad de rotación sobre su propio eje
    public Vector3 inclinacion; // Inclinación del planeta

    void Start()
    {
        // Aplicar la inclinación inicial
        transform.rotation = Quaternion.Euler(inclinacion);
    }

    void Update()
    {
        // Rotación sobre su propio eje
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);

        // Órbita alrededor del centro
        if (centroOrbita != null)
        {
            transform.RotateAround(centroOrbita.position, Vector3.up, velocidadOrbita * Time.deltaTime);
        }
    }
}

