using UnityEngine;

public class Enemies_HP : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // initial HP
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(gameObject.name + " got hit, remain HP¡G" + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject.name + " Enemy destoried ");
            Destroy(gameObject);
            UI_ScoreManager.Instance.EnemyDestroyed();
        }
    }
}
