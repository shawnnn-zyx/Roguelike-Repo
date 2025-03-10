using UnityEngine;

public class Weapon_Damage : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        // �T�O�Z�����쪺�O�Ǫ�
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
