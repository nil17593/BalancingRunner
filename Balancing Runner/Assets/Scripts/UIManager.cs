using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager UIInstance { get { return instance; } }

    #region Serialized Fields

    [Header("Pause Panel")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;

    [Header("Level Win Panel")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Button menu;

    [Header("Die Panel")]
    [SerializeField] private GameObject diePanel;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button menubtn;
    [SerializeField] private string menuScene;
    #endregion

    private bool isPaused=false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        retryButton.onClick.AddListener(Restart);
        menuButton.onClick.AddListener(LoadMenu);
        menu.onClick.AddListener(LoadMenu);
        menubtn.onClick.AddListener(LoadMenu);
    }

    private void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            Debug.Log("click");
            pausePanel.SetActive(true);
        }
    }

    private void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pausePanel.SetActive(false);
        }
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadDiePanel()
    {
        diePanel.SetActive(true);
    }

    public void LoadLevelWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
}