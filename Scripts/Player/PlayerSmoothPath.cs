using UnityEngine;
using Cinemachine;

public class PlayerSmoothPath : MonoBehaviour
{
    public static CinemachineSmoothPath playerSmoothPath;
    // Start is called before the first frame update
    void Awake()
    {
        playerSmoothPath = this.GetComponent<CinemachineSmoothPath>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
