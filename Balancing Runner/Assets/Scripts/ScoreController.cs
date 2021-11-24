using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI leftScoreText;
    //[SerializeField] private TextMeshProUGUI rightScoreText;
    private static ScoreController instance;
    public static ScoreController Instance { get { return instance; } }

    [SerializeField] private TextMeshProUGUI scoreText;
    private int totalScore;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        totalScore = PlayerPrefs.GetInt("TotalScore", totalScore);
        RefreshUI();
    }

    public void IncreaseScore(int increament)
    {
        totalScore += increament;
        RefreshUI();
        PlayerPrefs.SetInt("TotalScore", totalScore);
    }

    private void RefreshUI()
    {
        scoreText.text = " " + totalScore;
    }
}
