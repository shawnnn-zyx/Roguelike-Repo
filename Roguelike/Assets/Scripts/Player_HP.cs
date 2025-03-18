using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_HP : MonoBehaviour
{
    public int maxHealth = 100;
    public TextMeshProUGUI hpText;
    private int currentHealth;
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHPUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player got hit, remain HP: " + currentHealth);

        UpdateHPUI(); // ��s UI

        if (currentHealth <= 0)
        {
            Debug.Log("Player defeated! Loading Game Over scene...");
            SceneManager.LoadScene("00_GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            Debug.Log("Player hit an enemy! Taking damage.");
            TakeDamage(10);
        }
    }

    private void UpdateHPUI()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHealth.ToString();
        }
    }
}
