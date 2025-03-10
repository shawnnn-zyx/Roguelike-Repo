using UnityEngine;
using UnityEngine.AI;

public class Player_Movement : MonoBehaviour
{
    private NavMeshAgent agent; // NavMesh �N�z
    private Camera mainCamera;  // �D��v��

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // ���o NavMeshAgent
        mainCamera = Camera.main; // ���o�D��v��
    }

    void Update()
    {
        // ���a���U�ƹ�����
        if (Input.GetMouseButtonDown(0))
        {
            MoveToMouseClick();
        }
    }

    void MoveToMouseClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Raycast Hit: " + hit.collider.name); // �s�W�o��Ӱ�������������

            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}