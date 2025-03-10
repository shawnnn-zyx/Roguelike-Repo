using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_GoalChange : MonoBehaviour
{
    public string nextSceneName = "01_Start";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}


