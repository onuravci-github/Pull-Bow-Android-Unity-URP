using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxChange : MonoBehaviour
{
    public Material[] materials;

    private int materialNumb;
    // Start is called before the first frame update
    void Start()
    {
        materialNumb = (PlayerSetting.getLevel()/10) % 4;
        this.GetComponent<MeshRenderer>().material = materials[materialNumb];
    }

    // Update is called once per frame
    void Update()
    {
    }
}
