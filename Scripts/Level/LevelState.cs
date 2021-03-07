using UnityEngine;
using UnityEngine.UI;

public class LevelState : MonoBehaviour
{
    //Score 1000/1 Coin Star x 1.5 - 2 - 3
    public static int score;
    private int starGainNumb;
    //levelMapState == LevelMapLength is finish level.
    private int levelMapLength;
    public static float levelMapState;

    public static bool isFinish = false;

    public GameObject[] stars;

    public GameObject winPanel;
    // Start is called before the first frame update
    private void Start()
    {
        levelMapState = 0;
        isFinish = false;
        score = 0; 
        starGainNumb = 0;
        levelMapLength = PlaneMeshCreate.pointLength;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(transform.localScale.x < 1 ){
            transform.localScale = new Vector3(levelMapState/levelMapLength,1,1);
        }
        else if(!isFinish && transform.localScale.x >=1){ 
            isFinish = true;
            Invoke("LevelFinish",1f);
        }
        if(transform.localScale.x > 0.95f && PlayerProperty.health == PlayerProperty.maxHealth){
            stars[2].SetActive(true);
            starGainNumb = 3;
        }
        else if(transform.localScale.x > 0.6f && PlayerProperty.health == PlayerProperty.maxHealth){
            stars[1].SetActive(true);
            starGainNumb = 2;
        }
        else if(transform.localScale.x > 0.3f && PlayerProperty.health == PlayerProperty.maxHealth){
            stars[0].SetActive(true);
            starGainNumb = 1;
        }
    }

    private void LevelFinish(){
        GameObject winPanelObject = Instantiate(winPanel,transform.parent.position,Quaternion.identity,transform.parent);
        for (int i = 0; i < starGainNumb; i++) {
            winPanelObject.GetComponent<WinPanel>().stars[i].GetComponent<Image>().color = Color.white;
            winPanelObject.GetComponent<WinPanel>().starsOpen = i+1;
        }
        //winPanelObject.GetComponent<WinPanel>().score = score;
        PlayerSetting.setLevel(PlayerSetting.getLevel() +1);
    }

}
