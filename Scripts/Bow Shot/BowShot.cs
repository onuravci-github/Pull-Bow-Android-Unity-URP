using System.Collections.Generic;
using UnityEngine;

public class BowShot : MonoBehaviour
{
    public static bool shotStart = false;
    public static bool shotReady = false;

    public GameObject arrowObject;
    public GameObject arrowControlObject;

    public GameObject cursorObject;
    public GameObject cursorCircle;

    public GameObject shotRoadObject;
    private List<GameObject> enemyObjects;
    private float enemyX;
    private float enemyY;

    private float degreeY;
    private float degreeX;

    private Animator animator;
    private Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        enemyObjects = new List<GameObject>();
        shotStart = false;
        animator = this.GetComponent<Animator>();
        parentTransform = this.GetComponentInParent<PlayerProperty>().gameObject.transform;
        Invoke("Cursor",1f);
    }

    public void Cursor(){
        cursorObject = GameObject.FindGameObjectWithTag("Cursor");
        cursorCircle = GameObject.FindObjectOfType<CursorBow>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        int enemynumber = 0;
        for (int i = 0; i < enemyObjects.Count; i++)
        {
            if(enemyObjects.Count >=2 && i < enemyObjects.Count-1 && enemyObjects[i] != null){
                if(enemyObjects[i+1] != null){
                    if(enemyObjects[i].transform.position.x < enemyObjects[i+1].transform.position.x){
                        enemynumber = i;
                    }
                    else
                        enemynumber = i+1;
                }
            }
            else if (enemyObjects[i] != null){
                enemynumber = 0;
            }
            if(enemyObjects[i] == null){
                enemyObjects.RemoveAt(i);
            }
            
        }
        if(enemyObjects.Count >= 1 && enemyObjects[enemynumber]){
            enemyX = (enemyObjects[enemynumber].transform.position.x - transform.position.x);
            enemyY = (enemyObjects[enemynumber].transform.position.y - transform.position.y);
        }

        if(Time.timeScale > 0 && Input.mousePosition.y < Screen.height*0.80f){
            // Mouse0 Key Down
            if(Input.GetKeyDown(KeyCode.Mouse0) && shotStart && !animator.GetBool("Shot") && LevelState.isFinish == false ){
                animator.speed = 1*PlayerSetting.shotSpeed;
                animator.SetBool("Shot",true);
                cursorObject.transform.localScale = Vector3.one;
                cursorObject.transform.position = Input.mousePosition;
                shotRoadObject.SetActive(true);
            }
            //Mouse0 Key Active
            else if(Input.GetKey(KeyCode.Mouse0) && shotStart && cursorCircle.transform.localPosition != Vector3.zero ){
                degreeY = -Mathf.Clamp(cursorCircle.transform.localPosition.x/Mathf.Sqrt(Vector2.SqrMagnitude(cursorCircle.transform.localPosition))*75f,-60f,60f);
                degreeX = -Mathf.Asin(enemyY/Mathf.Sqrt((enemyX*enemyX) + (enemyY*enemyY)))*Mathf.Rad2Deg;
                
                if(enemyObjects.Count ==  0) degreeX = 0;
                // localEulerAngles problem Fix
                if(degreeX >-30 && degreeX < 30)
                    this.transform.localEulerAngles = new Vector3(degreeX - parentTransform.localEulerAngles.x,-(parentTransform.localEulerAngles.y-90)+degreeY,0);
                else{
                    this.transform.localEulerAngles = new Vector3(0,-(parentTransform.localEulerAngles.y-90)+degreeY,0);
                }
                
            }
            //Mouse0 Key Up
            else if(Input.GetKeyUp(KeyCode.Mouse0) && shotStart && animator.GetBool("Shot") && arrowControlObject == null){
                shotReady = false;
                animator.SetBool("Shot",false);
                cursorObject.transform.localScale = Vector3.zero;
                shotRoadObject.SetActive(false);

                this.transform.localEulerAngles = new Vector3(0,-(parentTransform.localEulerAngles.y-90)+degreeY,0);
            }
            else if(Input.GetKeyUp(KeyCode.Mouse0) && shotStart && animator.GetBool("Shot") && arrowControlObject != null){
                animator.speed = 1*PlayerSetting.shotSpeed;
                shotReady = false;
                arrowControlObject.transform.SetParent(null);
                arrowControlObject.transform.localScale = arrowObject.transform.localScale;
                arrowControlObject.GetComponent<Rigidbody>().velocity = 15*(arrowControlObject.GetComponentInChildren<Empty>().gameObject.transform.position - arrowControlObject.transform.position);

                arrowControlObject = null;

                cursorObject.transform.localScale = Vector3.zero;
                shotRoadObject.SetActive(false);
                animator.SetBool("Shot",false);

                this.transform.localEulerAngles = new Vector3(0,-(parentTransform.localEulerAngles.y-90)+degreeY,0);
            }
            
            if(PlayerProperty.health <= 0){
                this.transform.localEulerAngles = new Vector3(0,-(parentTransform.localEulerAngles.y-90),0);
                animator.speed = 1*PlayerSetting.shotSpeed;
            }
        }
        
        
    }

    
    public void SetBool(){
        animator.SetBool("Shot",false);
    }

    public void AnimationPause(){
        animator.speed = 0;
        arrowControlObject = Instantiate(arrowObject,this.transform.position,Quaternion.identity,transform);
        arrowControlObject.transform.localEulerAngles = Vector3.zero;
        arrowControlObject.transform.localScale = Vector3.zero;
        shotReady = true;
    }

    
        
    private void OnTriggerEnter(Collider other) {
        enemyObjects.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other) {
        enemyObjects.Remove(other.gameObject);
    }

    public void ReplayLevel(){
        LevelStartButton.ReplayLevel();
    }

}
