using UnityEngine;

public class Weapon_Lightening : MonoBehaviour
{
    public float attackRange = 10f;   
    public int damage = 20;           
    public Transform attackOrigin;    

    public LineRenderer lightningEffect; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CastLightning();
        }
    }

    void CastLightning()
    {
        RaycastHit hit;
        Vector3 startPoint = attackOrigin.position;
        Vector3 direction = attackOrigin.forward;

        if (Physics.Raycast(startPoint, direction, out hit, attackRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            Enemies_HP enemy = hit.collider.GetComponent<Enemies_HP>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            ShowLightningEffect(startPoint, hit.point);
        }
        else
        {
            ShowLightningEffect(startPoint, startPoint + direction * attackRange);
        }
    }

    void ShowLightningEffect(Vector3 start, Vector3 end)
    {
        if (lightningEffect != null)
        {
            lightningEffect.SetPosition(0, start);
            lightningEffect.SetPosition(1, end);
            lightningEffect.enabled = true;
            Invoke("DisableLightningEffect", 0.1f);
        }
    }

    void DisableLightningEffect()
    {
        if (lightningEffect != null)
        {
            lightningEffect.enabled = false;
        }
    }
}