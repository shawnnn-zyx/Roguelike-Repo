using UnityEngine;
using UnityEngine.AI;

public class Player_Movement : MonoBehaviour
{
    private NavMeshAgent agent; // NavMesh 代理
    private Camera mainCamera;  // 主攝影機

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // 取得 NavMeshAgent
        mainCamera = Camera.main; // 取得主攝影機
    }

    void Update()
    {
        // 當玩家按下滑鼠左鍵
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
            Debug.Log("Raycast Hit: " + hit.collider.name); // 新增這行來偵測擊中的物件

            if (hit.collider.gameObject.CompareTag("Ground"))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}