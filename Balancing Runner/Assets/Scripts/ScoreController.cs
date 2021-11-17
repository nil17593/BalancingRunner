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
        totalScore = 0;
        RefreshUI();
    }

    public void IncreaseScore(int increament)
    {
        totalScore += increament;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoreText.text = " " + totalScore;
    }
}
