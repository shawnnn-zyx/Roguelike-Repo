using UnityEngine;
using System.Collections;

public class Weapon_Swing : MonoBehaviour
{
    public GameObject weapon;
    public float swingSpeed = 360f; //angle per seconds
    public float maxSwingAngle = 70f; //swing angle
    private bool isSwinging = false;
    private float currentSwingAngle = 0f;
    private bool swingingForward = true;
    private Quaternion initialRotation;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            StartSwing();
        }

        if (isSwinging)
        {
            PerformSwing();
        }
    }

    void StartSwing()
    {
        isSwinging = true;
        swingingForward = true;
        currentSwingAngle = 0f;
        initialRotation = weapon.transform.localRotation;
    }

    void PerformSwing()
    {
        if (swingingForward)
        {
            currentSwingAngle += swingSpeed * Time.deltaTime;
            if (currentSwingAngle >= maxSwingAngle)
            {
                currentSwingAngle = maxSwingAngle;
                swingingForward = false;
            }
        }
        else
        {
            currentSwingAngle -= swingSpeed * Time.deltaTime;
            if (currentSwingAngle <= 0)
            {
                currentSwingAngle = 0;
                isSwinging = false;
            }
        }

        // 使用localRotation來相對於角色旋轉劍
        weapon.transform.localRotation = initialRotation * Quaternion.Euler(0, 0, -currentSwingAngle);
    }
}
