using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject panelWysp;
    public GameObject panelMenu;

    private void Start()
    {
        // Ukryj panelWysp na początku gry
        panelWysp.SetActive(false);
    }

    public void ShowPanelWysp()
    {
        panelWysp.SetActive(true);
        panelMenu.SetActive(false);
    }

    public void ShowPanelMenu()
    {
        panelWysp.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
