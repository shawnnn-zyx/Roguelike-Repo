using Unity.VisualScripting;
using UnityEngine;

public class Week9ScoreOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        //increase the score
        //relocate to new location from -4 to 4 on x and y
        //check if this makes a new high score
        Week9Gamemanager.instance.Score++;
        transform.position = new Vector3(Random.Range(-4, 4), Random.Range(-4, 4), 0);
    }
}
