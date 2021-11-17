using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RightCubeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rightScoreText;
    [SerializeField] private int increamentScore;
    [SerializeField] private int decreamentScore;
    private int totalScore;

    private void Start()
    {
        totalScore = 0;
        RefreshRightUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            Destroy(other.gameObject);
            StickController.StickInstance.RotateRight();
            IncreaseRightCount(increamentScore);
        }
        else if (other.CompareTag("Green"))
        {
            Debug.Log(other.name);
            Destroy(other.gameObject);
            StickController.StickInstance.RotateLeft();
            //if (totalScore > 1)
            //{
                DecreaseScore(decreamentScore);
            //}
        }
    }

    private void IncreaseRightCount(int increament)
    {
        totalScore += increament;
        RefreshRightUI();
    }

    private void RefreshRightUI()
    {
        rightScoreText.text = totalScore+"KG";
    }

    private void DecreaseScore(int decreament)
    {
        totalScore -= decreament;
        RefreshRightUI();
    }
}