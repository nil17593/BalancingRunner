using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private Transform player;
    [SerializeField] private Transform endLine;
    private float maxDistance;


    private void Start()
    {
        maxDistance = GetDistance();
    }
    public void Update()
    {
        if(player.position.z<=maxDistance && player.position.z <= endLine.position.z)
        {
            float distance = 1 - (GetDistance() / maxDistance);
            SetProgress(distance);
        }
    }

    float GetDistance()
    {
        return Vector3.Distance(player.position, endLine.position);
    }

    private void SetProgress(float progress)
    {
        progressBar.value = progress;
    }
}   
