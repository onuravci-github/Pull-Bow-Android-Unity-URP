using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    public GameObject[] stars;
    public int score;
    public static int coin;
    public int starsOpen;

    public Text scoreText;
    public Text coinText;
    public Text adsCoinText;
    public Text adsXText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        coin = 0;
        adsXText.text = "Star x" + (1 + starsOpen*0.5f).ToString("F1");
    }

    // Update is called once per frame
    void Update()
    {
        if(score < LevelState.score){
            score = score + 1000;
            scoreText.text = "Score " + score.ToString();
            if(score % 1000 == 0){
                coin++;
                coinText.text = "Gain " + coin.ToString();
                adsCoinText.text = (coin*(1 + starsOpen*0.5f)).ToString("F0");
            }
        }
        else{
            score = LevelState.score;
            coin = Mathf.FloorToInt(coin*(1 + starsOpen*0.5f)*PlayerSetting.coinX);
            scoreText.text = "Score " + score.ToString();
            coinText.text = "Gain " + coin.ToString();
            Destroy(this.GetComponent<WinPanel>());
        }
        
    }

    public void StarsOpen(){

    }
}
