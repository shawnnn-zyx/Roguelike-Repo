using UnityEngine;

public class WASDcontroller : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print in console
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("ova and ova");

        //get the position from this gameobjects transform
        Vector3 position = transform.position;

        //if player pressed W on the keyboard
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W pressed");
            position += new Vector3(0, moveSpeed, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");
            position += new Vector3(-moveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S pressed");
            position += new Vector3(0, -moveSpeed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D pressed");
            position += new Vector3(moveSpeed, 0, 0);
        }

        transform.position = position;
    }
}
