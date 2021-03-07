using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteButton : MonoBehaviour
{
    public VolumeProfile volumeProfile;
    public Vignette vignette;

    public Sprite[] sprite;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerSetting.getVignette() == 0){ 
            volumeProfile.TryGet(out vignette);
            vignette.intensity.value = 0.4f;
            if(this.GetComponent<Image>())  this.GetComponent<Image>().sprite = sprite[0];
        }
            
        else{
            volumeProfile.TryGet(out vignette);
            vignette.intensity.value = 0.25f;
            if(this.GetComponent<Image>())  this.GetComponent<Image>().sprite = sprite[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
          
    }
    public void VinyetOnOff(){
        if(PlayerSetting.getVignette() == 1){
            vignette.intensity.value = 0.4f;
            this.GetComponent<Image>().sprite = sprite[0];
            PlayerSetting.setVignette(0);
        }
        else{
            vignette.intensity.value = 0.25f;
            this.GetComponent<Image>().sprite = sprite[1];
            PlayerSetting.setVignette(1);
        }
    }

    

   

}
