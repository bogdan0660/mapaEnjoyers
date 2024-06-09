using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Dodaj tę linię na górze

public class ShowPanelOnClick : MonoBehaviour
{
    public Button openButton; 
    public Button closeButton; 
    public Button menuButton; // Nowa zmienna dla przycisku "Wróć do menu"
    public GameObject yourPanel; 

    void Start()
    {
        openButton.onClick.AddListener(ShowPanel);
        closeButton.onClick.AddListener(HidePanel);
        menuButton.onClick.AddListener(LoadMenuScene); // Dodaj tę linię
        yourPanel.SetActive(false);
    }

    void ShowPanel()
    {
        yourPanel.SetActive(true);
    }

    void HidePanel()
    {
        yourPanel.SetActive(false);
    }

    // Nowa funkcja do ładowania sceny menu
    void LoadMenuScene()
    {
        SceneManager.LoadScene("MainMenu"); // Zastąp "MenuSceneName" nazwą twojej sceny menu
    }
}
