using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}