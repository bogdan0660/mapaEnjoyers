using UnityEngine;

public class StartGameButto : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject gamePanel;

    public void OnStartGameButtonClicked()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
}
