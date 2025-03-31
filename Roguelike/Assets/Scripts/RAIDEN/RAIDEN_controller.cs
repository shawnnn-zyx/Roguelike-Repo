using UnityEngine;

public class RAIDEN_controller : MonoBehaviour
{
    [Header("移動控制")]
    public KeyCode keyLeft = KeyCode.A;    // 左移按鍵
    public KeyCode keyRight = KeyCode.D;   // 右移按鍵
    public float speed = 10f;              // 移動速度
    
    [Header("物件生成設定")]
    public GameObject spawnPrefab;         // 要生成的預製體
    public float spawnInterval = 1f;       // 生成間隔(秒)
    public float objectSpeed = 5f;         // 生成物件的移動速度
    public Transform spawnPoint;           // 生成位置參考點
    
    private Rigidbody rb;
    private float spawnTimer = 0f;         // 生成計時器

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation; // 鎖定旋轉
        
        // 若未指定生成點，預設使用自身位置
        if(spawnPoint == null) spawnPoint = transform;
    }

    void Update()
    {
        HandleMovement();
        HandleSpawning();
    }

    void HandleMovement()
    {
        // 左右移動控制
        if (Input.GetKey(keyLeft))
        {
            rb.linearVelocity = new Vector3(-speed, rb.linearVelocity.y, 0);
        }
        else if (Input.GetKey(keyRight))
        {
            rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, 0);
        }
        else
        {
            rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0); // 停止水平移動
        }
    }

    void HandleSpawning()
    {
        // 生成計時邏輯
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        if(spawnPrefab == null) return;

        // 在指定位置生成物件
        GameObject newObj = Instantiate(
            spawnPrefab,
            spawnPoint.position,
            Quaternion.identity
        );

        // 為生成的物件添加移動邏輯
        Rigidbody objRb = newObj.GetComponent<Rigidbody>();
        if(objRb == null) 
        {
            objRb = newObj.AddComponent<Rigidbody>();
        }
        
        // 設置向上移動速度
        objRb.linearVelocity = Vector3.up * objectSpeed;
        
        // 可選：自動銷毀(避免場景中物件過多)
        Destroy(newObj, 15f); // 15秒後自動銷毀
    }
}
