using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_gameManage : MonoBehaviour
{
    public static Character_gameManage instance;
    public int currentSceneNum;
    private Player_HP playerHP;
    private UI_ScoreManager playerScore;
    public int levelScore = 30;
    
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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHP = GameObject.Find("Player").GetComponent<Player_HP>();
        
        playerScore = GameObject.Find("UI_Manager").GetComponent<UI_ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerHP != null && playerHP.GetCurrentHealth() <= 0)
        {
            Debug.Log("Player defeated! Loading Game Over scene...");
            SceneManager.LoadScene("00_GameOver");
        }

        if (playerScore != null && playerScore.GetCurrentScore() >= levelScore)
        {
            //increase the levelScore by 50%
            levelScore += levelScore + levelScore / 2;
            
            Debug.Log("Win! to the next scene!");
            ChangeScene();
        }
    }
}
