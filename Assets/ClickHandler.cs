using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public Camera mainCamera;
    public float transitionSpeed = 2.0f;
    private bool isTransitioning = false;
    private Transform targetPlanet;
    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;
    public Text planetInfoText; // Asegúrate de que esta variable esté declarada

    void Start()
    {
        // Guardar la posición y rotación inicial de la cámara
        initialCameraPosition = mainCamera.transform.position;
        initialCameraRotation = mainCamera.transform.rotation;
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
                PlanetInfo planetInfo = hit.transform.GetComponent<PlanetInfo>();
                if (planetInfo != null)
                {
                    if (targetPlanet == hit.transform)
                    {
                        // Si el planeta ya está seleccionado, volver a la vista general
                        Debug.Log("Volviendo a la vista general");
                        isTransitioning = true;
                        targetPlanet = null;
                        planetInfoText.gameObject.SetActive(false);
                    }
                    else
                    {
                        // Seleccionar un nuevo planeta
                        Debug.Log("Planeta clickeado: " + hit.transform.name);
                        targetPlanet = hit.transform;
                        isTransitioning = true;
                        planetInfoText.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (isTransitioning)
        {
            if (targetPlanet != null)
            {
                // Transición hacia el planeta
                Vector3 targetPosition = targetPlanet.position + new Vector3(0, 0, 2);
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * transitionSpeed);
                mainCamera.transform.LookAt(targetPlanet);

                if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 4f)
                {
                    Debug.Log("Transición completada.");
                    isTransitioning = false;
                    // Detener la rotación del planeta alrededor del sol
                    targetPlanet.GetComponent<Orbita>().enabled = false;
                    // Mostrar información
                    ShowPlanetInfo(targetPlanet.GetComponent<PlanetInfo>());
                }
            }
            else
            {
                // Transición hacia la vista general
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, initialCameraPosition, Time.deltaTime * transitionSpeed);
                mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, initialCameraRotation, Time.deltaTime * transitionSpeed);

                if (Vector3.Distance(mainCamera.transform.position, initialCameraPosition) < 4f)
                {
                    Debug.Log("Vista general alcanzada.");
                    isTransitioning = false;
                    // Reanudar la rotación del planeta alrededor del sol
                    foreach (var planet in FindObjectsOfType<Orbita>())
                    {
                        planet.enabled = true;
                    }
                }
            }
        }
    }

    void ShowPlanetInfo(PlanetInfo planetInfo)
    {
        // Actualizar el texto con la información del planeta
        Debug.Log("Mostrando información de " + planetInfo.planetName);
        planetInfoText.text = planetInfo.planetName + ": " + planetInfo.planetDescription;
        planetInfoText.gameObject.SetActive(true);
    }
}







