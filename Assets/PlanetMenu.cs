using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    public GameObject planetMenuPanel;
    public Text planetInfoText;
    public Text generalDataText;
    public Text moonsText;
    public Text measurementsText;
    private PlanetInfo currentPlanetInfo;

    void Start()
    {
        // Ocultar el menú y los textos inicialmente
        planetMenuPanel.SetActive(false);
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        moonsText.gameObject.SetActive(false);
        measurementsText.gameObject.SetActive(false);
    }

    public void ShowMenu(PlanetInfo planetInfo)
    {
        currentPlanetInfo = planetInfo;
        planetMenuPanel.SetActive(true);
    }

    public void HideMenu()
    {
        planetMenuPanel.SetActive(false);
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        moonsText.gameObject.SetActive(false);
        measurementsText.gameObject.SetActive(false);
    }

    public void ShowGeneralData()
    {
        planetInfoText.gameObject.SetActive(false);
        moonsText.gameObject.SetActive(false);
        measurementsText.gameObject.SetActive(false);
        generalDataText.text = currentPlanetInfo.generalData;
        generalDataText.gameObject.SetActive(true);
    }

    public void ShowMoons()
    {
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        measurementsText.gameObject.SetActive(false);
        moonsText.text = currentPlanetInfo.moons;
        moonsText.gameObject.SetActive(true);
    }

    public void ShowMeasurements()
    {
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        moonsText.gameObject.SetActive(false);
        measurementsText.text = currentPlanetInfo.measurements;
        measurementsText.gameObject.SetActive(true);
    }
}





