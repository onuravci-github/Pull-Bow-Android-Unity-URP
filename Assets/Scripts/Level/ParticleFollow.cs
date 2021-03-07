using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 vector = new Vector3(50,0,-50);
    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.transform.position + vector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
