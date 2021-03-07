using UnityEngine;

public class SettingButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingOnOff(){
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
        } 
        else
            Time.timeScale = 1;
    }
}
