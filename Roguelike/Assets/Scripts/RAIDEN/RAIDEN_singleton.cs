using UnityEngine;

public class RAIDEN_singleton : MonoBehaviour
{
    public static RAIDEN_singleton instance;
    
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
