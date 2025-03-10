using UnityEngine;
using TMPro;

public class UI_ScoreManager : MonoBehaviour
{
    public static UI_ScoreManager Instance;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Coins: " + score;
        }
    }

    public void EnemyDestroyed()
    {
        AddScore(10);
    }
}
