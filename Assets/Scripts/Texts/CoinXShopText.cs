using UnityEngine;
using UnityEngine.UI;

public class CoinXShopText : MonoBehaviour
{
    // ShopNumber - 0 == CoinXCoin | 1 == CoinX Value LvNow  | 2 == CoinX Value LvAfter
    
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
            text.text = PlayerSetting.coinXCoin.ToString("F0");
        }
        else if(shopNumber == 1){
            text.text = PlayerSetting.coinX.ToString("F1");
        }
        else if(shopNumber == 2){
            text.text = (PlayerSetting.coinX + 0.5f).ToString("F1");
        }
    }
}
