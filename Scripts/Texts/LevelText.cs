using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private Text text;
    private Vector3 vector3;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        vector3 = this.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Level " + (PlayerSetting.getLevel()+1).ToString();
        this.transform.localEulerAngles = vector3;
    }
}
