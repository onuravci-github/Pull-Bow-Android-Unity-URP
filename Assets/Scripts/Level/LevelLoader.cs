using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Manuel make Levels
    public GameObject[] levels;
    // Player Decorations
    public GameObject[] player;
    // 0 = LandSpace | 1 = Portrait
    public GameObject[] cameras;

    public int levelNumb;
    public int playerNumb;
    public int cameraNumb;

    private void Awake() {
        if(PlayerSetting.getLevel() < 30){
            levelNumb = PlayerSetting.getLevel();
            Instantiate(levels[levelNumb],Vector3.zero,Quaternion.identity,transform);
        }
        else{
            Instantiate(levels[Random.Range(10,30)],Vector3.zero,Quaternion.identity,transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerNumb = PlayerSetting.getPlayer();
        cameraNumb = PlayerSetting.getScreenOrientation();

        Instantiate(player[playerNumb],Vector3.zero,Quaternion.identity,transform);
        Instantiate(cameras[cameraNumb],Vector3.zero,Quaternion.identity,transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
