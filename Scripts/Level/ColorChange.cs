using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    // colors2 for Plane
    public Color[] colors2;

    // Function 0 : Material Base color | 1 : Plane(Shader Graph) | 2 : Cloud(Emission)
    public int function;

    private int colorNumb;
    // Start is called before the first frame update
    void Start()
    {
        colorNumb = (PlayerSetting.getLevel()/10) % 4;
        if(function == 0){
            this.GetComponent<MeshRenderer>().materials[0].color = colors[colorNumb];
        }
        else if (function == 1){
            this.GetComponent<MeshRenderer>().material.SetColor("Color_1",colors[colorNumb]);
            this.GetComponent<MeshRenderer>().material.SetColor("Color_2",colors2[colorNumb]);
        }
        else if(function == 2){
            Resources.Load<Material>("Materials/Cloud").SetColor("_EmissionColor",colors[colorNumb]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
