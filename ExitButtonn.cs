using UnityEngine;
using UnityEngine.UI;

public class ExitButtonn : MonoBehaviour
{
    public GameObject panelToHide;
    public GameObject mainMenuPanel;

    public void OnExitButtonClicked()
    {
        // Wyłącz panel do ukrycia
        panelToHide.SetActive(false);

        // Włącz główny panel
        mainMenuPanel.SetActive(true);
    }
}
