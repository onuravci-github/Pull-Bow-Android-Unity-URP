using UnityEngine;

public class PlaneCreateAnim : MonoBehaviour
{
    private int distanceY = 5;

    private Vector3 startPosition;

    // 1 second/repeatTime =  50 x 0.1 = 5 br ;
    private float repeatTime = 0.02f;
    private float upValue = 0.1f;

    public bool destroy = false;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
        transform.position -= Vector3.up*distanceY;
        InvokeRepeating("PositionUp",repeatTime,repeatTime); 
    }

    private void PositionUp(){
        transform.position += Vector3.up*upValue;
        if(startPosition.y <= transform.position.y){
            CancelInvoke("PositionUp");
        }
    }
    private void Update() {
        if(PlaneMeshCreate.isLevelStart && !destroy){
            destroy = !destroy;
            Invoke("DestroyObject",11/PlayerProperty.speed);
        }
    }

    private void DestroyObject(){
        Destroy(gameObject);
    }
}