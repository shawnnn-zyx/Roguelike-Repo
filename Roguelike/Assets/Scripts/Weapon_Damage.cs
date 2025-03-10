using UnityEngine;

public class Weapon_Damage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        // 確保武器打到的是怪物
        if (other.CompareTag("Enemies"))
        {
            Enemies_HP enemyHP = other.GetComponent<Enemies_HP>();
            if (enemyHP != null)
            {
                enemyHP.TakeDamage(damageAmount);
            }
        }
    }
}
