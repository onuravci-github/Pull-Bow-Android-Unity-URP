using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public int[] createPointNumber;

    public GameObject[] enemies;

    PlaneMeshCreate planeMeshCreate;
    
    // Start is called before the first frame update
    void Start()
    {
        planeMeshCreate = this.GetComponentInParent<PlaneMeshCreate>();
    }

    public void CreateEnemy(){
        for (int i = 0; i < createPointNumber.Length; i++)
        {
            if(PlaneMeshCreate.cubeNumber +3 == createPointNumber[i]){
                GameObject enemy = Instantiate(enemies[i],CreatePointCreate(createPointNumber[i],enemies[i].GetComponent<Enemy>().enemyMovement),Quaternion.identity);
                enemy.GetComponent<Enemy>().positionNumber = createPointNumber[i];
            }
        } 
    }

    public Vector3 CreatePointCreate(int cubeNumber,int movementNumb){
        if(movementNumb == 0)
            return (PlayerSmoothPath.playerSmoothPath.m_Waypoints[cubeNumber].position +new Vector3(Random.Range(-0.5f,0.5f),-3f,Random.Range(-3f,3f)));
        else if(movementNumb == 1){
            //0: Left 1: Right
            int leftOrRight = Random.Range(0,2);
            if(leftOrRight == 0){
                return (PlayerSmoothPath.playerSmoothPath.m_Waypoints[cubeNumber].position +new Vector3(-0.5f,Random.Range(9,10f),Random.Range(12,14)));
            }
            else {
                return (PlayerSmoothPath.playerSmoothPath.m_Waypoints[cubeNumber].position +new Vector3(-0.5f,Random.Range(9,10f),Random.Range(-12,-14)));
            }
        }
        else
            return (PlayerSmoothPath.playerSmoothPath.m_Waypoints[cubeNumber].position +new Vector3(0,0.5f,Random.Range(-3.5f,3.5f)));
    }
}  
