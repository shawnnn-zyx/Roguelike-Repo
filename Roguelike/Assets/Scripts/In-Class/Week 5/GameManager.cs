using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //declare, initialize, lose it
    //array starts with 0

    //Vector:direction
    //Ray:point+direction

    public int[] intArray;

    public GameObject[] cubes;

    public List<GameObject> cubeList;

    GameObject cubeHolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeHolder = new GameObject("cubeHolder");

        intArray = new int[5];

        intArray[0] = 7;
        intArray[4] = 17;

        for (int i = 0; i < intArray.Length; i++)
        {
            //intArray[i] = 12;
            intArray[i] = Random.Range(0, 100);
        }

        //foreach (var intHolder in intArray)
        //{
        //    intHolder = 3;
        //}

        cubes = new GameObject[3];
        cubeList = new List<GameObject>();

        //primitive = enum
        //cubes[0] = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //cubes[0].transform.position = new Vector3 (0, 0, 0);

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubes[i].transform.position = new Vector3(
                Random.Range(-5, 5),
                Random.Range(-5, 5),
                Random.Range(-5, 5));

            //make child cubeHolder
            cubes[i].transform.parent = cubeHolder.transform;

            //add cube to cubeList
            cubeList.Add(cubes[i]);
            InvokeRepeating(nameof(SpawnCube), 1, 1);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    //可以用來做背景裝飾 搭配destory使用
    public void SpawnCube()
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        cubeList.Add(newCube);

        //make child cubeHolder
        newCube.transform.parent = cubeHolder.transform;
    }

    public void RemoveCube(GameObject cube)
    {
        cubeList.Remove(cube);
        Destroy(cube);
    }
}
