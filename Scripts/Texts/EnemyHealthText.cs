using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealthText : MonoBehaviour
{
    private TextMeshProUGUI text;

    public GameObject canvasObject;
    private Vector3 canvasPosition;
    // Start is called before the first frame update
    void Start()
    {
        canvasPosition = canvasObject.GetComponent<Transform>().localPosition;
        canvasObject = Instantiate(canvasObject,transform.position + canvasPosition,canvasObject.transform.rotation);
        text = canvasObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = this.GetComponent<Enemy>().health.ToString("F0");
        
        if ( this.GetComponent<Enemy>().health <= 0 && canvasObject)
        {
            Destroy(canvasObject.gameObject);
        }
        else if(canvasObject)
            canvasObject.transform.position = this.transform.position + canvasPosition;
        else{
            Destroy(canvasObject.gameObject);
        }
    }
}
