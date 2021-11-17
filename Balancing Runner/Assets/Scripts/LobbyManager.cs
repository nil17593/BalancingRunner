using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;


    private void Start()
    {
        playButton.onClick.AddListener(LoadGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("Level1");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}