using UnityEngine;

public class ChannelChanger : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    public RenderTexture tvTexture;
    
    public bool isCamera2 = false;
    
    
    public bool IsCamera2
    {
        get
        {
            return isCamera2;
        }
        set
        {
            isCamera2 = value;

            if (isCamera2)
            {
                camera2.targetTexture = tvTexture;
                camera1.targetTexture = null;
                //camera1.enabled = false;
                //camera2.enabled = true;
            }
            else //using camera 1
            {
                camera1.targetTexture = tvTexture;
                camera2.targetTexture = null;
                //camera2.enabled = false;
                //camera1.enabled = true;
            }
        }
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            IsCamera2 = !IsCamera2;
        }
    }
}
