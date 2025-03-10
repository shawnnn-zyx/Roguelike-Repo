using UnityEngine;
using System.Collections.Generic;

public class Enemies_Spawn : MonoBehaviour
{
    public int[] intArray;
    public GameObject[] cubes;
    public List<GameObject> cubeList;
    private GameObject cubeHolder;

    void Start()
    {
        InitializeCubeHolder();
        InitializeIntArray();
        InitializeCubes();
    }

    void InitializeCubeHolder()
    {
        cubeHolder = new GameObject("cubeHolder");
    }

    void InitializeIntArray()
    {
        intArray = new int[5];
        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = Random.Range(0, 100);
        }
    }

    void InitializeCubes()
    {
        cubes = new GameObject[3];
        cubeList = new List<GameObject>();

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = CreateRandomCube();
            cubeList.Add(cubes[i]);
        }

        InvokeRepeating(nameof(SpawnCube), 1, 1);
    }

    GameObject CreateRandomCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(
            Random.Range(-13, -26),
            1,
            Random.Range(-11, 21));
        cube.transform.localScale = new Vector3(1, 2, 1);
        cube.transform.parent = cubeHolder.transform;
        cube.tag = "Enemies";
        cube.AddComponent<Enemies_Movement>();
        cube.AddComponent<Enemies_HP>();

        BoxCollider bc = cube.GetComponent<BoxCollider>();
        bc.isTrigger = true;

        Rigidbody rb = cube.AddComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;

        rb.constraints = RigidbodyConstraints.FreezePositionY;

        return cube;
    }

    public void SpawnCube()
    {
        GameObject newCube = CreateRandomCube();
        cubeList.Add(newCube);
    }

    public void RemoveCube(GameObject cube)
    {
        if (cube.CompareTag("Enemies")) //destroy tag object
        {
            cubeList.Remove(cube);
            Destroy(cube);
        }
    }

    void Update()
    {
        // 留空以備將來使用
    }
}