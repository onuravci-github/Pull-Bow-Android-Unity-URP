using UnityEngine;
using UnityEngine.UI;

public class ScreenOrientationButton : MonoBehaviour
{
    public Image[] sprites;

    private void Start() {

        if(PlayerSetting.getScreenOrientation() == 0){
            // LAndspace Ayarı
        }
        else{
            //Portrait Ayarı
        }
        
        SpriteColorUpdate(PlayerSetting.getScreenOrientation());
    }

    public void LandSpace(){
        if(PlayerSetting.getScreenOrientation() == 1){
            PlayerSetting.setScreenOrientation(0);
            SpriteColorUpdate(0);
            // LAndspace Ayarı
        }
    }
    public void Portrait(){
        if(PlayerSetting.getScreenOrientation() == 0){
            PlayerSetting.setScreenOrientation(1);
            SpriteColorUpdate(1);
            // Portrait Ayarı
        }
    }

    public void SpriteColorUpdate(int numb){
        for (int i = 0; i < 2; i++) {
            if(i == numb){
                sprites[i].color = Color.white;
            } 
            else  
                sprites[i].color = new Color(1,1,1,0.5f);
        }
    }
}
