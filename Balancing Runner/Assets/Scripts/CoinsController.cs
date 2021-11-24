using System.Collections;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>()!=null)
        {
            ScoreController.Instance.IncreaseScore(1);
            gameObject.SetActive(false);
        }
    }
}