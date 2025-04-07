using System;
using UnityEngine;
using UnityEngine.Windows;
using File = System.IO.File;
using Input = UnityEngine.Input;

public class Week9Gamemanager : MonoBehaviour
{
    int score = 0; //private variable

    //public property which wraps private var score
    public int Score
    {
        get { return score; }

        set
        {
            score = value;

            if (score > HighScore)
            {
                HighScore = score;
            }

            Debug.Log("The score is now " + score);
        }
    }

    int highScore = 10;
    
    const string KEY_HIGH_SCORE = "HIGH SCORE";
    
    const string FILE_NAME = "/highScoreFile.txt";

    string FILE_PATH;
    
    int[] highScoreArray = new int[5];

    void Start()
    {
        FILE_PATH = Application.persistentDataPath + FILE_NAME;
    }
    
    public int HighScore
    {
    get{
        //highScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE);
        string fileContent = File.ReadAllText(FILE_PATH + FILE_NAME);
        
        highScore = Int32.Parse(fileContent);
        
        return highScore;}
    set
    { 
        highScore = value;
        
        PlayerPrefs.SetInt(KEY_HIGH_SCORE, highScore);
        
        Debug.Log("FILE: " + FILE_PATH + FILE_NAME);

        string highScoreString = highScore + ",";

        for (int i = 0; i < highScoreArray.Length; i++)
        {
            highScoreString += highScoreArray[i] + ",";
        }
        highScoreString = highScoreString.Substring(
            highScoreString.Length - 1);
        
        File.WriteAllText(FILE_PATH + FILE_NAME, highScoreString);
        
        Debug.Log("New High Score: " + score);
    }
    }

    public static Week9Gamemanager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Score++;
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey(KEY_HIGH_SCORE);
        //PlayerPrefs.DeleteAll();
    }
}
