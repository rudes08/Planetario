using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    public GameObject planetMenuPanel;
    public Text planetInfoText;
    public Text generalDataText;
    public Text moonsText;
    public Text measurementsText;
    public Button backButton; // Botón de regresar
    private PlanetInfo currentPlanetInfo;

    void Start()
    {
        // Ocultar el menú y los textos inicialmente
        planetMenuPanel.SetActive(false);
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        moonsText.gameObject.SetActive(false);
        measurementsText.gameObject.SetActive(false);

        // Asegurarse de que el botón de regresar siempre esté visible
        backButton.gameObject.SetActive(true);
        backButton.onClick.AddListener(BackToGeneralView);
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
        generalDataText.text = FormatText(currentPlanetInfo.generalData);
        generalDataText.gameObject.SetActive(true);
    }

    public void ShowMoons()
    {
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        measurementsText.gameObject.SetActive(false);
        moonsText.text = FormatText(currentPlanetInfo.moons);
        moonsText.gameObject.SetActive(true);
    }

    public void ShowMeasurements()
    {
        planetInfoText.gameObject.SetActive(false);
        generalDataText.gameObject.SetActive(false);
        moonsText.gameObject.SetActive(false);
        measurementsText.text = FormatText(currentPlanetInfo.measurements);
        measurementsText.gameObject.SetActive(true);
    }

    private void BackToGeneralView()
    {
        // Lógica para regresar a la vista general
        ClickHandler clickHandler = Camera.main.GetComponent<ClickHandler>();
        if (clickHandler != null)
        {
            clickHandler.HandlePlanetClick(null);
        }
    }

    private string FormatText(string text)
    {
        // Reemplazar '|' con saltos de línea
        text = text.Replace("|", "\n");
        return text;
    }
}


















