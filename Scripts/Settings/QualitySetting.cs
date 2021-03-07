using UnityEngine;
using UnityEngine.UI;

public class QualitySetting : MonoBehaviour
{
    public Image[] sprites;

    private void Start() {
        QualitySettings.vSyncCount = 1 ;
        Application.targetFrameRate = 60;
        QualitySettings.SetQualityLevel(PlayerSetting.getQuality());
        SpriteColorUpdate(PlayerSetting.getQuality());
    }

    public void FastQuality(){
        QualitySettings.SetQualityLevel(0);
        PlayerSetting.setQuality(0);
        SpriteColorUpdate(0);
        
    }
    public void GoodQuality(){
        QualitySettings.SetQualityLevel(1);
        PlayerSetting.setQuality(1);
        SpriteColorUpdate(1);
    }
    public void HighQuality(){
        QualitySettings.SetQualityLevel(2);
        PlayerSetting.setQuality(2);
        SpriteColorUpdate(2);
    }
    public void UltraQuality(){
        QualitySettings.SetQualityLevel(3);
        PlayerSetting.setQuality(3);
        SpriteColorUpdate(3);
    }

    public void SpriteColorUpdate(int numb){
        if(sprites.Length != 0){
            for (int i = 0; i < 4; i++) {
                if(i == numb){
                    sprites[i].color = Color.white;
                    //PlayerSetting.setQuality(i);
                } 
                else  
                    sprites[i].color = new Color(1,1,1,0.5f);
            }
        }
        
    }
}
