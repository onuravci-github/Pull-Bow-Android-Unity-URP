using UnityEngine;
using UnityEngine.UI;

public class ShotSpeedShopText : MonoBehaviour
{
    // ShopNumber - 0 == ShotSpeedCoin | 1 == ShotSpeed Value LvNow  | 2 == ShotSpeed Value LvAfter
    
    public int shopNumber;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(shopNumber == 0){
            text.text = PlayerSetting.shotSpeedCoin.ToString("F0");
        }
        else if(shopNumber == 1){
            text.text = PlayerSetting.shotSpeed.ToString("F1");
        }
        else if(shopNumber == 2){
            text.text = (PlayerSetting.shotSpeed + 0.1f).ToString("F1");
        }
    }
}
