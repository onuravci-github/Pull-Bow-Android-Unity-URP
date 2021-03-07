using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Saturation : MonoBehaviour
{
    public VolumeProfile volumeProfile;
    public ColorAdjustments saturation;

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        volumeProfile.TryGet(out saturation);
        slider = this.GetComponent<Slider>();
        slider.value = PlayerSetting.getSaturation();
        saturation.saturation.value = slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerSetting.getSaturation() != slider.value){
            saturation.saturation.value = slider.value;
            PlayerSetting.setSaturation((int)slider.value);
        }
    }
}
