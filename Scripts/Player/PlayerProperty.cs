using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    public static float health;
    public static int maxHealth;
    public static float speed = 0.8f;

    private bool isDead;

    private void Awake() {
        speed = 0.8f;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = PlayerSetting.health;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && !isDead){
            isDead = !isDead;
            PlayerProperty.speed = 0;
            this.GetComponentInChildren<Animator>().SetBool("Dead",true);
        }
           
    }
    
    public static void HealthUpdate(){
        maxHealth = PlayerSetting.health;
        health = maxHealth;
    }
}
