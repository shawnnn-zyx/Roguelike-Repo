using UnityEngine;

public class ObjectClicker3D : MonoBehaviour
{
    GameManager gameManager;
    void Start()
    {
        //getting reference to another gameObject in our scene
        GameObject gameManagerHolder = GameObject.Find("GameManagerHolder");
        //getting the component off of another gameObject
        gameManager = gameManagerHolder.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if left click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            //generate a ray from the camera eye to the point on the screen where the cursor currently is
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
            // inside the if statement is a boolean
            // send out a ray cast based on out ray return ture if it hits something, else false
            // 
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit Something" + hit.collider.name);
                gameManager.RemoveCube(hit.collider.gameObject);
            }
            else
            {
                Debug.Log("Missed the Tagrget");
            }
        }
    }
}
