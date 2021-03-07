using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    const string HEALTH = "health";

	public static void setHealth (int numb){
		PlayerPrefs.SetInt(HEALTH,numb);
	}
	public static int getHealth() {
		return PlayerPrefs.GetInt(HEALTH);
	}

    const string POWER = "power";

	public static void setPower (int numb){
		PlayerPrefs.SetInt(POWER,numb);
	}
	public static int getPower() {
		return PlayerPrefs.GetInt(POWER);
	}

    const string COIN_X = "coin_x";

	public static void setCoinX (int numb){
		PlayerPrefs.SetInt(COIN_X,numb);
	}
	public static int getCoinX() {
		return PlayerPrefs.GetInt(COIN_X);
	}

    const string SHOT_SPEED = "shot_speed";

	public static void setShotSpeed (int numb){
		PlayerPrefs.SetInt(SHOT_SPEED,numb);
	}
	public static int getShotSpeed() {
		return PlayerPrefs.GetInt(SHOT_SPEED);
	}

	const string COIN = "coin";

	public static void setCoin (float numb){
		PlayerPrefs.SetFloat(COIN,numb);
	}
	public static float getCoin() {
		return PlayerPrefs.GetFloat(COIN);
	}

	const string LEVEL = "level";

	public static void setLevel (int numb){
		PlayerPrefs.SetInt(LEVEL,numb);
	}
	public static int getLevel() {
		return PlayerPrefs.GetInt(LEVEL);
	}

	const string PLAYER = "player";

	public static void setPlayer (int numb){
		PlayerPrefs.SetInt(PLAYER,numb);
	}
	public static int getPlayer() {
		return PlayerPrefs.GetInt(PLAYER);
	}

	const string GAME_OPEN = "game_open";

	public static void setGameOpen (int numb){
		PlayerPrefs.SetInt(GAME_OPEN,numb);
	}
	public static int getGameOpen() {
		return PlayerPrefs.GetInt(GAME_OPEN);
	}


	// 0 = LandSpace | 1 = Portrait 
	const string SCREENORIENTATION = "screen_orientation";

	public static void setScreenOrientation (int numb){
		PlayerPrefs.SetInt(SCREENORIENTATION,numb);
	}
	public static int getScreenOrientation() {
		return PlayerPrefs.GetInt(SCREENORIENTATION);
	}

	// 0 = Fast | 1 = Good | 2 = High | 3 = Ultra 
	const string QUALITY = "quality";

	public static void setQuality (int numb){
		PlayerPrefs.SetInt(QUALITY,numb);
	}
	public static int getQuality() {
		return PlayerPrefs.GetInt(QUALITY);
	}

	// Saturation Range[-30,30];
	const string SATURATION = "saturation";

	public static void setSaturation (int numb){
		PlayerPrefs.SetInt(SATURATION,numb);
	}
	public static int getSaturation() {
		return PlayerPrefs.GetInt(SATURATION);
	}

	// Vignette 0 = On | 1 = Off
	const string VIGNETTE = "vignette";

	public static void setVignette (int numb){
		PlayerPrefs.SetInt(VIGNETTE,numb);
	}
	public static int getVignette() {
		return PlayerPrefs.GetInt(VIGNETTE);
	}

	// Sound 0 = On | 1 = Off
	const string SOUND = "sound";

	public static void setSound (int numb){
		PlayerPrefs.SetInt(SOUND,numb);
	}
	public static int getSound() {
		return PlayerPrefs.GetInt(SOUND);
	}

	// Sfx 0 = On | 1 = Off
	const string SFX = "sfx";

	public static void setSfx (int numb){
		PlayerPrefs.SetInt(SFX,numb);
	}
	public static int getSfx() {
		return PlayerPrefs.GetInt(SFX);
	}



	public static int powerCoin;
	public static int shotSpeedCoin;
	public static int coinXCoin;
	public static int healthCoin;

	public static float power;
	public static float shotSpeed;
	public static float coinX;
	public static int health;

    // Start is called before the first frame update
    void Awake()
    {
		if(getGameOpen() == 0){
			setHealth(1);
			setCoinX(1);
			setPower(1);
			setShotSpeed(1);
			setLevel(0);
			setQuality(2);
		}
		setGameOpen(getGameOpen() + 1);
		ShopPropertyValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public static void ShopPropertyValue(){
		powerCoin = getPower() * (10 * (getPower()/10 +1));
		shotSpeedCoin = getShotSpeed() * 50 * ((getShotSpeed()/5)*4 +1);
		coinXCoin = getCoinX() * 100 * ((getCoinX()/2) *10 +1);
		healthCoin = getHealth() * (20 * (getHealth()/10 +1));
		power = 5 + (getPower()*5);
		shotSpeed = 0.9f + (getShotSpeed() * 0.1f);
		coinX = 0.5f + (getCoinX() * 0.5f);
		health = 0 + (getHealth()*5);
	}
}
