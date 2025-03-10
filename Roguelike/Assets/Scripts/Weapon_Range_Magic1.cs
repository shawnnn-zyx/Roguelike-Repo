using UnityEngine;

public class Weapon_Range_Magic1 : MonoBehaviour
{
    public float attackRange = 12f;   // 雷電最大攻擊距離
    public int damage = 20;           // 攻擊傷害
    public Transform attackOrigin;    // 雷電發射點（可以是角色手掌）

    public LineRenderer lightningEffect; // 雷電視覺效果（需在 Unity Inspector 設定）
    public int segments = 50; // 圓形範圍的分段數
    public float radius = 5f; // 雷電範圍的半徑
    public Color rangeColor = Color.blue; // 攻擊範圍顏色

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) // 按下鍵盤2施放雷電
        {
            CastLightning();
        }
    }

    void CastLightning()
    {
        RaycastHit hit;
        Vector3 startPoint = attackOrigin.position;
        Vector3 direction = attackOrigin.forward;

        // 發射 Raycast，檢測敵人
        if (Physics.Raycast(startPoint, direction, out hit, attackRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            // 如果擊中敵人，造成傷害
            Enemies_HP enemy = hit.collider.GetComponent<Enemies_HP>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            // 顯示雷電效果
            ShowLightningEffect(startPoint, hit.point);
            DealDamageInRange(hit.point); // 在範圍內造成傷害
        }
    }

    // 顯示雷電效果
    void ShowLightningEffect(Vector3 start, Vector3 end)
    {
        if (lightningEffect != null)
        {
            lightningEffect.SetPosition(0, start); // 設定起點
            lightningEffect.SetPosition(1, end);   // 設定終點
            lightningEffect.enabled = true;
            Invoke("DisableLightningEffect", 0.1f); // 0.1秒後隱藏
        }
    }

    // 隱藏雷電效果
    void DisableLightningEffect()
    {
        if (lightningEffect != null)
        {
            lightningEffect.enabled = false;
        }
    }

    // 在範圍內對敵人造成傷害
    void DealDamageInRange(Vector3 center)
    {
        // 使用OverlapSphere來檢測範圍內的敵人
        Collider[] hitEnemies = Physics.OverlapSphere(center, radius);

        foreach (var enemy in hitEnemies)
        {
            if (enemy.CompareTag("Enemies"))
            {
                // 在這裡對敵人造成傷害
                Enemies_HP enemyHP = enemy.GetComponent<Enemies_HP>();
                if (enemyHP != null)
                {
                    enemyHP.TakeDamage(damage);
                }
            }
        }

        // 顯示範圍效果
        DrawCircle(center);
    }

    // 繪製範圍圓形
    void DrawCircle(Vector3 center)
    {
        if (lightningEffect != null)
        {
            lightningEffect.positionCount = segments + 1; // 設置點數
            for (int i = 0; i <= segments; i++)
            {
                float angle = i * Mathf.PI * 2 / segments;  // 計算每個點的角度
                Vector3 point = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
                lightningEffect.SetPosition(i, center + point);  // 設置Line Renderer的每個點
            }
        }
    }
}