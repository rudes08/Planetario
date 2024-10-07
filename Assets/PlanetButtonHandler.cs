using UnityEngine;
using UnityEngine.UI;

public class PlanetButtonHandler : MonoBehaviour
{
    public ClickHandler clickHandler; // Referencia al script ClickHandler
    public Transform planetTransform; // Referencia al transform del planeta correspondiente

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        if (clickHandler != null && planetTransform != null)
        {
            clickHandler.HandlePlanetClick(planetTransform);
        }
    }
}

