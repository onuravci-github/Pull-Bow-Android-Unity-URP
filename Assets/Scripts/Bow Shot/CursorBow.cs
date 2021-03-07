using UnityEngine;
using UnityEngine.UI;

public class CursorBow : MonoBehaviour
{
    public static bool isMovable = true;

    private Vector3 tempMousePosition;
    private Vector3 downMouse;

    private Color redColor = new Color(1,0.5f,0.6f);
    private Color greenColor = new Color(0.16f,1,0.81f);

    public Image [] images;
    float rate = 1;
    // Start is called before the first frame update
    void Start()
    {
        isMovable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            rate = 1;
            downMouse = Input.mousePosition;
            ShotNotReady();
        }
        else if(Input.GetKey(KeyCode.Mouse0)&& isMovable){
            if(rate != 0)
            transform.localPosition = (Input.mousePosition - downMouse)/rate;
        }
        else if(!isMovable){
            float a = Vector3.Magnitude(transform.position - downMouse);
            float b = Vector3.Magnitude(Input.mousePosition - downMouse);
            if(a != 0) rate = b/a;
            if(rate!=0)tempMousePosition = (Input.mousePosition - downMouse)/(rate*1.05f);
            transform.localPosition = tempMousePosition;
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            ShotNotReady();
        }
        if(BowShot.shotReady){
            ShotReady();
        }
    }
    void ShotReady(){
        images[0].color = greenColor;
        images[0].GetComponent<Transform>().localScale = Vector3.one*1.5f;
        images[1].color = greenColor;
        images[1].GetComponent<Transform>().localScale = Vector3.one*1.5f;
    }
    void ShotNotReady(){
        images[0].color = redColor;
        images[0].GetComponent<Transform>().localScale = Vector3.one;
        images[1].color = redColor;
        images[1].GetComponent<Transform>().localScale = Vector3.one;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Cursor")isMovable = false;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Cursor")isMovable = true;
    }
}
