using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Button loadLevelButton;
    [SerializeField] private string levelName;

    private void Awake()
    {
        loadLevelButton = GetComponent<Button>();
        loadLevelButton.onClick.AddListener(OnCliCk);

    }

    //function for different button operations
    private void OnCliCk()
    {
        LevelManager.LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);

        switch (levelStatus)
        {
            case LevelManager.LevelStatus.Locked:
                Debug.Log("cant load level is locked");
                break;

            case LevelManager.LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;

            case LevelManager.LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;
        }
    }
}