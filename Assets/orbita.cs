using UnityEngine;

public class Orbita : MonoBehaviour
{
    public Transform centroOrbita; // El objeto alrededor del cual orbita
    public float velocidadOrbita; // Velocidad de la �rbita
    public float velocidadRotacion; // Velocidad de rotaci�n sobre su propio eje
    public Vector3 inclinacion; // Inclinaci�n del planeta

    void Start()
    {
        // Aplicar la inclinaci�n inicial
        transform.rotation = Quaternion.Euler(inclinacion);
    }

    void Update()
    {
        // Rotaci�n sobre su propio eje
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);

        // �rbita alrededor del centro
        if (centroOrbita != null)
        {
            transform.RotateAround(centroOrbita.position, Vector3.up, velocidadOrbita * Time.deltaTime);
        }
    }
}

