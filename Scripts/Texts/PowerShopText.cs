using UnityEngine;
using UnityEngine.UI;

public class PowerShopText : MonoBehaviour
{
    // ShopNumber - 0 == PowerCoin | 1 == Power Value LvNow  | 2 == Power Value LvAfter
    
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
            text.text = PlayerSetting.powerCoin.ToString("F0");
        }
        else if(shopNumber == 1){
            text.text = PlayerSetting.power.ToString("F0");
        }
        else if(shopNumber == 2){
            text.text = (PlayerSetting.power + 5).ToString("F0");
        }
    }
}
