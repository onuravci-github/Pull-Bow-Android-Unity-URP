using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Text healthText;
    public bool isDead;

    // Start is called before the first frame update
    private void Start() {
        isDead = false;
        healthText = GetComponentInParent<Text>();
    }

    // Update is called once per frame
    private void Update() {
        if(PlayerProperty.health > 0){
            transform.localScale = new Vector3(PlayerProperty.health/PlayerProperty.maxHealth,1,1);
            healthText.text = PlayerProperty.health.ToString();
        }
        else if (!isDead){
            isDead = true;
            healthText.text = "0";
            transform.localScale = new Vector3(0,1,1);
        }
        else{
            transform.localScale = Vector3.zero;
        }
    }
}
