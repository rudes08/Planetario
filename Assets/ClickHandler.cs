using UnityEngine;
using UnityEngine.UI;

public class ClickHandler : MonoBehaviour
{
    public Camera mainCamera;
    public Transform targetPlanet;
    public float transitionSpeed = 2.0f;
    private bool isTransitioning = false;
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
                Debug.Log("Transici�n completada.");
                isTransitioning = false;
                // Detener la rotaci�n del planeta
                targetPlanet.GetComponent<Orbita>().enabled = false;
                // Mostrar informaci�n
                ShowPlanetInfo();
            }
        }
    }

    void ShowPlanetInfo()
    {
        // Actualizar el texto con la informaci�n del planeta
        Debug.Log("Mostrando informaci�n de Mercurio");
        planetInfoText.text = "Mercurio: El planeta m�s cercano al sol.";
        planetInfoText.gameObject.SetActive(true);
    }
}



