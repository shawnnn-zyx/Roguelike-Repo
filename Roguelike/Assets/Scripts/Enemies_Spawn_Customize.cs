using UnityEngine;
using System.Collections.Generic;

public class Enemies_Spawn_Customize : MonoBehaviour
{
    public int[] intArray;
    public GameObject[] enemies;
    public List<GameObject> enemyList;
    private GameObject enemyHolder;
    public GameObject enemyPrefab;

    void Start()
    {
        InitializeEnemiesHolder();
        InitializeIntArray();
        InitializeEnemies();
    }

    void InitializeEnemiesHolder()
    {
        enemyHolder = new GameObject("enemiesHolder2");
    }

    void InitializeIntArray()
    {
        intArray = new int[5];
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = Random.Range(0, 100);
        }
    }

    void InitializeEnemies()
    {
        enemies = new GameObject[3];
        enemyList = new List<GameObject>();

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = CreateRandomEnemy();
            enemyList.Add(enemies[i]);
        }

        InvokeRepeating(nameof(SpawnEnemy), 1, 1);
    }

    GameObject CreateRandomEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(
            Random.Range(-13, -26),
            1,
            Random.Range(-11, 21)),
            Quaternion.identity);
        enemy.transform.parent = enemyHolder.transform;
        enemy.tag = "Enemies";
        enemy.AddComponent<Enemies_Movement>();
        enemy.AddComponent<Enemies_HP>();

        BoxCollider bc = enemy.GetComponent<BoxCollider>();
        bc.isTrigger = true;

        Rigidbody rb = enemy.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        rb.constraints = RigidbodyConstraints.FreezePositionY;

        return enemy;
    }

    public void SpawnEnemy()
    {
        GameObject newEnemy = CreateRandomEnemy();
        enemyList.Add(newEnemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemy.CompareTag("Enemies")) //destroy tag object
        {
            enemyList.Remove(enemy);
            Destroy(enemy);
        }
    }

    void Update()
    {
        // 留空以備將來使用
    }
}