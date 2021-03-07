using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite[] sprite;
    public static bool isSoundOn;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerSetting.getSound() == 0){ 
            isSoundOn = true;
            this.GetComponent<Image>().sprite = sprite[0];
        }
        else{
            isSoundOn = false;
            this.GetComponent<Image>().sprite = sprite[1];
        }
    }
    private void Update() {
        if(PlayerSetting.getSound() == 0){ 
            isSoundOn = true;
            this.GetComponent<Image>().sprite = sprite[0];
        }
        else{
            isSoundOn = false;
            this.GetComponent<Image>().sprite = sprite[1];
        }
    }


    public void SoundOnOff(){
        if(PlayerSetting.getSound() == 1){
            isSoundOn = true;
            this.GetComponent<Image>().sprite = sprite[0];
            PlayerSetting.setSound(0);
        }
        else{
            isSoundOn = false;
            this.GetComponent<Image>().sprite = sprite[1];
            PlayerSetting.setSound(1);
        }
    }
}
