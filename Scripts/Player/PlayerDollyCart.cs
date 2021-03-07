using UnityEngine;
using Cinemachine;

public class PlayerDollyCart : MonoBehaviour
{
    public static CinemachineDollyCart playerDolly;

    // Start is called before the first frame update
    void Awake()
    {
        playerDolly = this.GetComponent<CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
