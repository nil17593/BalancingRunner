using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeftCubeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leftScoreText;
    private int totalScore;
    [SerializeField] private int increamentScore;
    [SerializeField] private int decreamentScore;

    private void Start()
    {
        totalScore = 0;
        RefreshLeftUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GreenCollectibleCubeController>() != null)
        {
            StickController.StickInstance.RotateLeft();
            IncreaseLeftCount(increamentScore);
            Destroy(other.gameObject);
        }
        else if (other.GetComponent<RedCollectibleCubeController>() != null)
        {
            Destroy(other.gameObject);
            StickController.StickInstance.RotateRight();
            //if (totalScore > 1)
            //{
            DecreaseScore(decreamentScore);
            //}
        }
    }

    private void IncreaseLeftCount(int increament)
    {
        totalScore += increament;
        RefreshLeftUI();
    }

    private void RefreshLeftUI()
    {
        leftScoreText.text = totalScore+"KG";
    }

    private void DecreaseScore(int decreament)
    {
            totalScore -= decreament;
            RefreshLeftUI();

    }
}
