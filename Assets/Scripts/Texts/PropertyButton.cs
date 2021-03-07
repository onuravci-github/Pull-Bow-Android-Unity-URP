using UnityEngine;
using UnityEngine.UI;

public class PropertyButton : MonoBehaviour
{
    //ShopNumber - Power == 0 | ShotSpeed = 1 | CoinX = 2 | Health = 3
    public int ShopNumber;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(ShopNumber == 1){
            if(PlayerSetting.getShotSpeed() == 21){
                this.GetComponent<Image>().enabled = false;
            }
        }
    }

    public void ShopUpButton(){
        PlayerSetting.ShopPropertyValue();

        if(ShopNumber == 0){
            if(PlayerSetting.getCoin() >= PlayerSetting.powerCoin){
                PlayerSetting.setCoin(PlayerSetting.getCoin() - PlayerSetting.powerCoin);
                PlayerSetting.setPower(PlayerSetting.getPower() + 1);
                PlayerSetting.ShopPropertyValue();
            }
        }
        else if(ShopNumber == 1){
            if(PlayerSetting.getCoin() >= PlayerSetting.shotSpeedCoin && PlayerSetting.getShotSpeed() <= 20){
                PlayerSetting.setCoin(PlayerSetting.getCoin() - PlayerSetting.shotSpeedCoin);
                PlayerSetting.setShotSpeed(PlayerSetting.getShotSpeed() + 1);
                PlayerSetting.ShopPropertyValue();
                if(PlayerSetting.getShotSpeed() == 21){
                    this.GetComponent<Image>().enabled = false;
                }
            }
        }
        else if(ShopNumber == 2){
            if(PlayerSetting.getCoin() >= PlayerSetting.coinXCoin){
                PlayerSetting.setCoin(PlayerSetting.getCoin() - PlayerSetting.coinXCoin);
                PlayerSetting.setCoinX(PlayerSetting.getCoinX() + 1);
                PlayerSetting.ShopPropertyValue();
            }
        }
        else if(ShopNumber == 3){
            if(PlayerSetting.getCoin() >= PlayerSetting.healthCoin){
                PlayerSetting.setCoin(PlayerSetting.getCoin() - PlayerSetting.healthCoin);
                PlayerSetting.setHealth(PlayerSetting.getHealth() + 1);
                PlayerSetting.ShopPropertyValue();
                PlayerProperty.HealthUpdate();
            }
        }
    }
}
