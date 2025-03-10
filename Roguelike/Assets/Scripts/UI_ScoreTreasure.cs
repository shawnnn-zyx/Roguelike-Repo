using UnityEngine;
using TMPro;

public class UI_ScoreTreasure : MonoBehaviour
{
    public int scoreValue = 1000;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_ScoreManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}