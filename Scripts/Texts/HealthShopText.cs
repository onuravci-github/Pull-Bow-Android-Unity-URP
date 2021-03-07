using UnityEngine;
using UnityEngine.UI;

public class HealthShopText : MonoBehaviour
{
    // ShopNumber - 0 == HealthCoin | 1 == Health Value LvNow  | 2 == Health Value LvAfter
    
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
            text.text = PlayerSetting.healthCoin.ToString("F0");
        }
        else if(shopNumber == 1){
            text.text = PlayerSetting.health.ToString("F0");
        }
        else if(shopNumber == 2){
            text.text = (PlayerSetting.health + 5).ToString("F0");
        }
    }
}
