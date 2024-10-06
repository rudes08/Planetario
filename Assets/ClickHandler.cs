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
    public Text planetInfoText; // Aseg�rate de que esta variable est� declarada
    public PlanetMenu planetMenu; // Referencia al script PlanetMenu

    void Start()
    {
        // Guardar la posici�n y rotaci�n inicial de la c�mara
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
                    HandlePlanetClick(hit.transform);
                }
            }
        }

        if (isTransitioning)
        {
            if (targetPlanet != null)
            {
                // Transici�n hacia el planeta
                Vector3 targetPosition = targetPlanet.position + new Vector3(0, 0, -2);
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * transitionSpeed);
                mainCamera.transform.LookAt(targetPlanet);

                if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 4f)
                {
                    Debug.Log("Transici�n completada.");
                    isTransitioning = false;
                    // Detener la rotaci�n del planeta alrededor del sol
                    targetPlanet.GetComponent<Orbita>().enabled = true;
                    // Mostrar el men�
                    planetMenu.ShowMenu(targetPlanet.GetComponent<PlanetInfo>());
                }
            }
            else
            {
                // Transici�n hacia la vista general
                mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, initialCameraPosition, Time.deltaTime * transitionSpeed);
                mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, initialCameraRotation, Time.deltaTime * transitionSpeed);

                if (Vector3.Distance(mainCamera.transform.position, initialCameraPosition) < 0.1f)
                {
                    Debug.Log("Vista general alcanzada.");
                    isTransitioning = false;
                    // Reanudar la rotaci�n del planeta alrededor del sol
                    foreach (var planet in FindObjectsOfType<Orbita>())
                    {
                        planet.enabled = true;
                    }
                }
            }
        }
    }

    public void HandlePlanetClick(Transform planetTransform)
    {
        if (planetTransform == null || targetPlanet == planetTransform)
        {
            // Si el planeta ya est� seleccionado o se hace clic en el bot�n de regresar, volver a la vista general
            Debug.Log("Volviendo a la vista general");
            isTransitioning = true;
            targetPlanet = null;
            planetInfoText.gameObject.SetActive(false);
            planetMenu.HideMenu();
            if (planetTransform != null)
            {
                planetTransform.GetComponent<Orbita>().enabled = true;
            }
        }
        else
        {
            // Seleccionar un nuevo planeta
            Debug.Log("Planeta clickeado: " + planetTransform.name);
            if (targetPlanet != null)
            {
                targetPlanet.GetComponent<Orbita>().enabled = true;
            }
            targetPlanet = planetTransform;
            isTransitioning = true;
            planetInfoText.gameObject.SetActive(false);
            planetMenu.HideMenu();
            planetTransform.GetComponent<Orbita>().enabled = false;
        }
    }
}
















