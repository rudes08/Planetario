using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetPlanet;
    public float transitionSpeed = 2.0f;
    private bool isTransitioning = false;
    public Text planetInfoText; // Asegúrate de que esta variable esté declarada

    void Start()
    {
        // Ocultar el texto inicialmente
        planetInfoText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == targetPlanet)
                {
                    Debug.Log("Planeta clickeado: " + hit.transform.name);
                    isTransitioning = true;
                }
            }
        }

        if (isTransitioning)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPlanet.position + new Vector3(0, 0, -10), Time.deltaTime * transitionSpeed);
            mainCamera.transform.LookAt(targetPlanet);

            if (Vector3.Distance(mainCamera.transform.position, targetPlanet.position + new Vector3(0, 0, -10)) < 0.1f)
            {
                Debug.Log("Transición completada.");
                isTransitioning = false;
                // Detener la rotación del planeta
                targetPlanet.GetComponent<Orbita>().enabled = false;
                // Mostrar información
                ShowPlanetInfo();
            }
        }
    }

    void ShowPlanetInfo()
    {
        // Actualizar el texto con la información del planeta
        Debug.Log("Mostrando información de Mercurio");
        planetInfoText.text = "Mercurio: El planeta más cercano al sol.";
        planetInfoText.gameObject.SetActive(true);
    }
}



