using UnityEngine;

public class Weapon_Range_Magic1 : MonoBehaviour
{
    public float attackRange = 12f;   // �p�q�̤j�����Z��
    public int damage = 20;           // �����ˮ`
    public Transform attackOrigin;    // �p�q�o�g�I�]�i�H�O�����x�^

    public LineRenderer lightningEffect; // �p�q��ı�ĪG�]�ݦb Unity Inspector �]�w�^
    public int segments = 50; // ��νd�򪺤��q��
    public float radius = 5f; // �p�q�d�򪺥b�|
    public Color rangeColor = Color.blue; // �����d���C��

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) // ���U��L2�I��p�q
        {
            CastLightning();
        }
    }

    void CastLightning()
    {
        RaycastHit hit;
        Vector3 startPoint = attackOrigin.position;
        Vector3 direction = attackOrigin.forward;

        // �o�g Raycast�A�˴��ĤH
        if (Physics.Raycast(startPoint, direction, out hit, attackRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // �p�G�����ĤH�A�y���ˮ`
            Enemies_HP enemy = hit.collider.GetComponent<Enemies_HP>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // ��ܹp�q�ĪG
            ShowLightningEffect(startPoint, hit.point);
            DealDamageInRange(hit.point); // �b�d�򤺳y���ˮ`
        }
    }

    // ��ܹp�q�ĪG
    void ShowLightningEffect(Vector3 start, Vector3 end)
    {
        if (lightningEffect != null)
        {
            lightningEffect.SetPosition(0, start); // �]�w�_�I
            lightningEffect.SetPosition(1, end);   // �]�w���I
            lightningEffect.enabled = true;
            Invoke("DisableLightningEffect", 0.1f); // 0.1�������
        }
    }

    // ���ùp�q�ĪG
    void DisableLightningEffect()
    {
        if (lightningEffect != null)
        {
            lightningEffect.enabled = false;
        }
    }

    // �b�d�򤺹�ĤH�y���ˮ`
    void DealDamageInRange(Vector3 center)
    {
        // �ϥ�OverlapSphere���˴��d�򤺪��ĤH
        Collider[] hitEnemies = Physics.OverlapSphere(center, radius);

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemies"))
            {
                // �b�o�̹�ĤH�y���ˮ`
                Enemies_HP enemyHP = enemy.GetComponent<Enemies_HP>();
                if (enemyHP != null)
                {
                    enemyHP.TakeDamage(damage);
                }
            }
        }

        // ��ܽd��ĪG
        DrawCircle(center);
    }

    // ø�s�d����
    void DrawCircle(Vector3 center)
    {
        if (lightningEffect != null)
        {
            lightningEffect.positionCount = segments + 1; // �]�m�I��
            for (int i = 0; i <= segments; i++)
            {
                float angle = i * Mathf.PI * 2 / segments;  // �p��C���I������
                Vector3 point = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
                lightningEffect.SetPosition(i, center + point);  // �]�mLine Renderer���C���I
            }
        }
    }
}