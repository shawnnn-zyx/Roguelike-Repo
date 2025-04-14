using UnityEngine;

public class AnimationSwitch : MonoBehaviour
{
    public Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("ChangeToGrow", true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("ChangeToGrow", false);
        }
    }
}
