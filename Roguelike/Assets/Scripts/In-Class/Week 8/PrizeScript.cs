using UnityEngine;

public class PrizeScript : MonoBehaviour
{
    public int positionRange = 5;
    void OnCollisionEnter(Collision Other)
    {
        GameManagerWeek8.instance.score++; 
        
        transform.position = new Vector3(
            Random.Range(-positionRange, positionRange),
            Random.Range(-positionRange, positionRange),
            0
            );
    }
}
