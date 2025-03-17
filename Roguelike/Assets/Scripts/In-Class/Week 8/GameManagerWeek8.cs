using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerWeek8 : MonoBehaviour
{
    public int score;
    public int levelScore = 3;
    
    public static GameManagerWeek8 instance;

    public TextMeshPro tmp;
    
    public float timeRemaining = 20;
    public int currentSceneNum;
    
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
    
    void ChangeScene()
    {
        currentSceneNum++;

        SceneManager.LoadScene(currentSceneNum + 1);
    }
    
    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        
        tmp.text = "Level: " + currentSceneNum + " Time Remaining: " + Mathf.Floor(timeRemaining);
        
        //if the time ran out
        //go to GameOver scene
        if (timeRemaining <= 0)
        {
            SceneManager.LoadScene("Week 8 GameOver");
            
            Destroy(gameObject);
        }
        
        //if the player hit levelScore
        if (score >= levelScore)
        {
            //increase the levelScore by 50%
            levelScore += levelScore + levelScore / 2;
            
            //then move to the next scene
            ChangeScene();
        }
    }
}
