using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // enemyMovement = 0 : Barrels | 1 : Fly | 2 : Guns 
    public int enemyMovement;
    public float health;
    public float maxHealth;
    public float power;
    public int powerUp;
    public float coin;
    public int score;
    public float speed;
    private Rigidbody enemyRigid;

    public int positionNumber;

    private List<Vector3> startPosition = new List<Vector3>();
    private List<Vector3> positions = new List<Vector3>();
    private List<Vector3> tempPositions = new List<Vector3>();

    private Vector3[] diversion;

    [Range(0.6f,0.9f)] private float intensityValue = 0.6f;

    private Transform playerTransform;
    public GameObject healthBar;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {   
        coin  = Mathf.CeilToInt(coin  * (PlayerSetting.getLevel() + 1) * PlayerSetting.coinX * ((PlayerSetting.getLevel())/30+1)*2);
        power = power + (PlayerSetting.getLevel() + 1)*powerUp * ((PlayerSetting.getLevel())/30+1)*2;
        score = score * (PlayerSetting.getLevel() + 1);

        HealthBarCreate();

        enemyRigid = this.GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if(enemyMovement == 0){
            DiversionCreate0();
            Invoke("PointsCreate",Time.deltaTime);
        }
        else if(enemyMovement == 1){
            DiversionCreate1();
            Invoke("PointsCreate",Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyMovement == 0 || enemyMovement == 1){
            EnemyUpdate();
        }
        else if(enemyMovement == 2){
            GunUpdate();
        }
    }

    void EnemyUpdate(){
        if(!isDead){
            if(positions.Count >= 1){
                for (int i = 0; i < positions.Count-1; i++) {
                    if(transform.position.x <= positions[i].x && PlaneMeshCreate.isLevelStart){
                        if(enemyMovement == 0){
                            enemyRigid.velocity = Vector3.Normalize(positions[i+1] -  positions[i])*speed - Vector3.up*2;
                        }
                        else if(enemyMovement == 1){
                            enemyRigid.velocity = Vector3.Normalize(positions[i+1] -  positions[i])*speed;
                            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation (enemyRigid.velocity),0.05f);
                        }
                        
                    }
                }
            }
            if(startPosition.Count >= 2){
                if(transform.position.x < startPosition[1].x){
                    positionNumber--;
                    PointsCreate();
                }
            }
        }
        if(healthBar != null)HealthBarUpdate();
    }
    
    void GunUpdate(){
        if(playerTransform.position.x - this.transform.position.x >= -0.3){
            Destroy(healthBar);
            this.GetComponent<Animator>().SetBool("Destroy",true);
        }
        Vector3 distance = Vector3.Normalize(playerTransform.position -this.transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(distance),0.05f);

        if((this.transform.position.x - playerTransform.position.x) < 13 && !isDead){
            Destroy(healthBar);
            this.GetComponent<Animator>().SetBool("Destruction",true);
            Destroy(this.GetComponent<EnemyHealthText>().canvasObject);
            isDead = true;
        }
        if(healthBar != null)HealthBarUpdate();
    }
    public void GunShot(){
        PlayerProperty.health = PlayerProperty.health - power;
    }
    

    public void PointsCreate(){
        positions.Clear();
        startPosition.Clear();

        for (int i = positionNumber; i >= PlayerDollyCart.playerDolly.m_Position ; i--)
        { 
            if(i-1 < Mathf.CeilToInt(PlayerDollyCart.playerDolly.m_Position)){
                startPosition.Add(PlayerSmoothPath.playerSmoothPath.m_Waypoints[i].position);
                startPosition.Add(playerTransform.position);
            }
            else if(i == positionNumber) { 
                startPosition.Add(this.transform.position); 
            }
            else{
                int diversionNumb = positionNumber - Mathf.CeilToInt(PlayerDollyCart.playerDolly.m_Position);
                startPosition.Add(PlayerSmoothPath.playerSmoothPath.m_Waypoints[i].position + diversion[diversionNumb]);
            }
        }
        positions.AddRange(startPosition);
        EnemyRoadCreate(1);
    }

    private void EnemyRoadCreate(int count){
        tempPositions.Clear();

        if(count <= 2){ 
            for (int i = 0; i < positions.Count; i++) {
                if(i == 0){
                    tempPositions.Add(positions[i]);
                }
                if(i == positions.Count-1){
                    tempPositions.Add(positions[i]);
                }
                else{
                    if( i != 0)
                        tempPositions.Add((positions[i+1] + ((positions[i] - positions[i+1])*intensityValue)));
                    if(i != positions.Count-2)
                        tempPositions.Add((positions[i] + ((positions[i+1] - positions[i])*intensityValue)));
                }
            }
            positions.Clear();
            positions.AddRange(tempPositions);
            EnemyRoadCreate((count+1));
        }
        else{
            return;
        }
    }
    private void DiversionCreate0(){
        diversion = new Vector3[] {
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            Vector3.zero,
            new Vector3(0,0,Random.Range(-0.5f,0.5f)),
            new Vector3(0,0,Random.Range(-0.5f,0.5f)),
            new Vector3(0,0,Random.Range(-1.5f,1.5f)),
            new Vector3(0,0,Random.Range(-2.5f,2.5f)),
            new Vector3(0,0,Random.Range(-3f,3f))
        };
    }
    private void DiversionCreate1(){
        // Left
        if(transform.position.z > 0){
            diversion = new Vector3[] {
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                new Vector3(0,Random.Range(0f,1f),Random.Range(1f,2f)),
                new Vector3(0,Random.Range(1f,3f),Random.Range(3f,6f)),
                new Vector3(0,Random.Range(3f,5f),Random.Range(5f,11f)),
                new Vector3(0,Random.Range(5f,7f),Random.Range(8f,12f)),
                new Vector3(0,Random.Range(7f,9f),Random.Range(12f,14f))
            };
        }
        // Right
        else{
            diversion = new Vector3[] {
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                Vector3.zero,
                new Vector3(0,Random.Range(0f,1f),Random.Range(-1f,-2f)),
                new Vector3(0,Random.Range(1f,3f),Random.Range(-3f,-6f)),
                new Vector3(0,Random.Range(3f,5f),Random.Range(-5f,-11f)),
                new Vector3(0,Random.Range(5f,7f),Random.Range(-8f,-12f)),
                new Vector3(0,Random.Range(7f,9f),Random.Range(-12f,-14f))
            };
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player" && enemyMovement != 2) {
            PlayerProperty.health = PlayerProperty.health - power;
            isDead = true;
            enemyRigid.velocity = Vector3.zero;
            Destroy(healthBar);
            this.GetComponent<Animator>().SetBool("Destruction",true);
            Destroy(this.GetComponent<EnemyHealthText>().canvasObject);
        }
    }
    private void HealthBarCreate() {
        maxHealth = Mathf.FloorToInt(health + (health * (PlayerSetting.getLevel())/2f * ((PlayerSetting.getLevel())/30+1)));
        health = maxHealth;
        healthBar = Instantiate(healthBar,transform.position + Vector3.up*1.5f,healthBar.transform.rotation);
    }
    private void HealthBarUpdate() {
        healthBar.transform.localScale = new Vector3((health/maxHealth)*2,0.2f,0.2f);
        healthBar.transform.position = transform.position + Vector3.up*1.5f;
    }
    private void Destroyer(){
        Destroy(gameObject);
    }
}
