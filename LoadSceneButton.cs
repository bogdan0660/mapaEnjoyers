using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneToLoad; // Nazwa sceny do załadowania

    void Start()
    {
        // Dodaj listener do przycisku
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        // Załaduj wybraną scenę
        SceneManager.LoadScene(sceneToLoad);
    }
}
