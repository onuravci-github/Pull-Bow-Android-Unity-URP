using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    Transform cameraTransform;

    PlaneMeshCreate planeMeshCreate;
    
    private CinemachineDollyCart dollyCart;
    private CinemachineSmoothPath smoothPath;
    private CinemachinePathBase path;


    private Vector3 position;
    private Vector3 targetPosition;
    private float targetPosX;
    private float targetPosY;
    private float targetPosZ;
    private float rotateX;
    private float rotateY;
    
    // Start is called before the first frame update
    void Start()
    {
        planeMeshCreate = GameObject.FindObjectOfType<PlaneMeshCreate>().GetComponent<PlaneMeshCreate>();
        cameraTransform = GameObject.FindGameObjectWithTag("CameraRoad").gameObject.transform;

        dollyCart = GameObject.FindGameObjectWithTag("CameraRoad").GetComponent<CinemachineDollyCart>();
        path = dollyCart.m_Path;
        smoothPath = path.GetComponent<CinemachineSmoothPath>();

        smoothPath.m_Waypoints = new CinemachineSmoothPath.Waypoint[PlaneMeshCreate.pointLength];

        smoothPath.m_Waypoints[0].position = new Vector3(-10,0,-2);
        smoothPath.m_Waypoints[1].position = new Vector3(-8,2,-2.75f);
        smoothPath.m_Waypoints[2].position = new Vector3(-5,4,-3.5f);
        for (int i = 3; i < PlaneMeshCreate.pointLength; i++) {
            //smoothPath.m_Waypoints[i].position = planeMeshCreate.createPoints[i-2] + new Vector3(1,6.5f,-3);
            
            if(planeMeshCreate.createPoints[i-2].y > -65){
                smoothPath.m_Waypoints[i].position = planeMeshCreate.createPoints[i-2] + new Vector3(1.5f,7f,-2.5f);
                //new Vector3(2.5f,8f,-1f); Portrait
            }
            else{
                smoothPath.m_Waypoints[i].position = planeMeshCreate.createPoints[i-2] + new Vector3(1.5f,105,-2.5f);
            }
        }
        GameObject.FindGameObjectWithTag("CameraRoad").GetComponent<CinemachineDollyCart>().m_Speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraTransform.position;
        if(PlaneMeshCreate.isLevelStart){
            GameObject.FindGameObjectWithTag("CameraRoad").GetComponent<CinemachineDollyCart>().m_Speed = PlayerProperty.speed;
        }
        if(dollyCart.m_Position > 2.5f && dollyCart.m_Position < smoothPath.m_Waypoints.Length - 3){
            position = smoothPath.EvaluatePosition(dollyCart.m_Position + 0.8f);
            targetPosition = smoothPath.EvaluatePosition(dollyCart.m_Position + 0.81f);
            targetPosX = (targetPosition.x - position.x);
            targetPosY = (targetPosition.y - position.y);
            targetPosZ = (targetPosition.z - position.z);

            rotateX = 15 - (Mathf.Asin(targetPosY/Mathf.Sqrt((targetPosX*targetPosX) + (targetPosY*targetPosY)))*Mathf.Rad2Deg)/2;
            rotateY = 80 - (Mathf.Asin(targetPosZ/Mathf.Sqrt((targetPosX*targetPosX) + (targetPosZ*targetPosZ)))*Mathf.Rad2Deg)/3;
            transform.localEulerAngles = new Vector3(rotateX,rotateY,0);
        }
        
    }
}
