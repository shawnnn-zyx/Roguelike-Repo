using TMPro;
using Unity.Collections;
using UnityEngine;

public class SubmitName : MonoBehaviour
{
    public TextMeshProUGUI inputfield;

    public string playerName = "";

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The current name is : " + inputfield.text);
    }

    public void PlayerNamer()
    {
        playerName = inputfield.text;
        Debug.Log("The player name is : " + inputfield.text);
    }
}