using UnityEngine;
using UnityEngine.UI;

public class SfxButton : MonoBehaviour
{
    public Sprite[] sprite;
    public static bool isSfxOn;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerSetting.getSfx() == 0){ 
            isSfxOn = true;
            this.GetComponent<Image>().sprite = sprite[0];
        }
        else{
            isSfxOn = false;
            this.GetComponent<Image>().sprite = sprite[1];
        }
    }
    private void Update() {
        if(PlayerSetting.getSound() == 0){ 
            isSfxOn = true;
            this.GetComponent<Image>().sprite = sprite[0];
        }
        else{
            isSfxOn = false;
            this.GetComponent<Image>().sprite = sprite[1];
        }
    }

    public void SfxOnOff(){
        if(PlayerSetting.getSfx() == 1){
            isSfxOn = true;
            this.GetComponent<Image>().sprite = sprite[0];
            PlayerSetting.setSfx(0);
        }
        else{
            isSfxOn = false;
            this.GetComponent<Image>().sprite = sprite[1];
            PlayerSetting.setSfx(1);
        }
    }
}
