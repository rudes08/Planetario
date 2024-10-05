using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public Camera mainCamera;
    public float transitionSpeed = 2.0f;
    private bool isTransitioning = false;
    private Transform targetPlanet;
    public Text planetInfoText; // Aseg�rate de que esta variable est� declarada

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
                PlanetInfo planetInfo = hit.transform.GetComponent<PlanetInfo>();
                if (planetInfo != null)
                {
                    Debug.Log("Planeta clickeado: " + hit.transform.name);
                    targetPlanet = hit.transform;
                    isTransitioning = true;
                }
            }
        }

        if (isTransitioning && targetPlanet != null)
        {
            Vector3 targetPosition = targetPlanet.position + new Vector3(0, 0, -2);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * transitionSpeed);
            mainCamera.transform.LookAt(targetPlanet);

            if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.8f)
            {
                Debug.Log("Transici�n completada.");
                isTransitioning = false;
                // Detener la rotaci�n del planeta
                targetPlanet.GetComponent<Orbita>().enabled = false;
                // Mostrar informaci�n
                ShowPlanetInfo(targetPlanet.GetComponent<PlanetInfo>());
            }
        }
    }

    void ShowPlanetInfo(PlanetInfo planetInfo)
    {
        // Actualizar el texto con la informaci�n del planeta
        Debug.Log("Mostrando informaci�n de " + planetInfo.planetName);
        planetInfoText.text = planetInfo.planetName + ": " + planetInfo.planetDescription;
        planetInfoText.gameObject.SetActive(true);
    }
}






