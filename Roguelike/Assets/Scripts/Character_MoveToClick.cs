using UnityEngine;

public class Character_MoveToClick : MonoBehaviour
{
    public float speed = 5f;  // ���Ⲿ�ʳt��
    private Vector3 targetPosition;  // �ؼЦ�m
    private bool isMoving = false;  // �O�_���b����

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // �ƹ��I����
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))  // ����I�����@�ɮy��
            {
                targetPosition = hit.point;
                isMoving = true;
            }
        }

        if (isMoving)  // �����Ⲿ��
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // ��F�ؼ�
            {
                isMoving = false;
            }
        }
    }
}