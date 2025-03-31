using UnityEngine;

public class RAIDEN_enemy : MonoBehaviour
{
    public int positionRange = 20; // 隨機生成位置的範圍
    public float objectSpeed = 5f; // 向下移動的速度

    void Update()
    {
        // 持續向下移動
        transform.Translate(Vector3.down * objectSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        // 增加分數
        RAIDEN_gamemanager.instance.score++;

        // 重置位置到隨機位置
        transform.position = new Vector3(
            Random.Range(-positionRange, positionRange),
            44,
            40
        );
    }
}
