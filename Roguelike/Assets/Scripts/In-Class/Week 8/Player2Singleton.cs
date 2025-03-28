using UnityEngine;

public class Player2Singleton : MonoBehaviour
{
    public static Player2Singleton instance;
    
    void Awake()
    {
        //if the instance has not been set
        if (instance == null)
        {
            //make this object instance
            instance = this;
            //讓分數邏輯可以運作下去
            DontDestroyOnLoad(gameObject);
        }
        //otherwise
        else
        {
            //destroy myself
            Destroy(gameObject);
        }
    }
}
