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
    public StickController stickController;

    private void Start()
    {
        totalScore = 0;
        RefreshRightUI();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RedCollectibleCubeController>() != null)
        {
            Destroy(other.gameObject);
            //StickController.StickInstance.RotateRight();
            stickController.RotateRight();
            IncreaseRightCount(increamentScore);
        }
        else if (other.GetComponent<GreenCollectibleCubeController>() != null)
        {
            Destroy(other.gameObject);
            //StickController.StickInstance.RotateLeft();
            stickController.RotateLeft();
            DecreaseScore(decreamentScore);
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
