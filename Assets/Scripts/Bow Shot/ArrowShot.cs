using UnityEngine;

public class ArrowShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroyer",3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy" && this.GetComponent<Rigidbody>().velocity != Vector3.zero){
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.health -= PlayerSetting.power; 
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
            if(enemy.health <= 0){
                Destroy(enemy.healthBar);
                other.gameObject.GetComponent<Animator>().SetBool("Destroy",true);
                other.gameObject.GetComponent<Collider>().enabled = false;
                PlayerSetting.setCoin(PlayerSetting.getCoin() + enemy.coin);
                LevelState.score += enemy.score;
                ScoreUp.score = enemy.score;
                CoinUp.coin = enemy.coin;
                FindObjectOfType<ScoreUp>().GetComponent<Animator>().SetBool("Plus",true);
                FindObjectOfType<CoinUp>().GetComponent<Animator>().SetBool("Plus",true);
            }
            Invoke("ShotDestroy",0.2f);
        }
    }
    private void ShotDestroy(){
        Destroy(this.gameObject);
    }

    private void Destroyer(){
        if(this.GetComponent<Rigidbody>().velocity != Vector3.zero){
            Destroy(this.gameObject);
        }
        else{
            Invoke("Destroyer",3.5f);
        }

    }
}
