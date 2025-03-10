using UnityEngine;

public class Character_MoveToClick : MonoBehaviour
{
    public float speed = 5f;  // 角色移動速度
    private Vector3 targetPosition;  // 目標位置
    private bool isMoving = false;  // 是否正在移動

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // 滑鼠點擊時
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  // 獲取點擊的世界座標
            {
                targetPosition = hit.point;
                isMoving = true;
            }
        }

        if (isMoving)  // 讓角色移動
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // 抵達目標
            {
                isMoving = false;
            }
        }
    }
}