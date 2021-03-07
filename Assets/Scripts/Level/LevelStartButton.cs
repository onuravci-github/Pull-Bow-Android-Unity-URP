using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelStart(){
        PlaneMeshCreate.isLevelStart = true;
    } 

    public void NextLevel(){
        SceneManager.LoadScene(0);
        PlayerSetting.setCoin(PlayerSetting.getCoin() + WinPanel.coin);
    }
    public static void ReplayLevel(){
        SceneManager.LoadScene(0);
    }
}
