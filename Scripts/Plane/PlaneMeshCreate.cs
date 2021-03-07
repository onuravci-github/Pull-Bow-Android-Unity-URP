using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlaneMeshCreate : MonoBehaviour
{
    //Top Railing
    public GameObject railingObject;
    //Finish line Decoration
    public GameObject decorationObject;

    //Basic cube triangle point numbers
    private static int[] trianglesSource = new int[]{
        0, 2, 3, 0, 3, 1,	
        8, 4, 5, 8, 5, 9,	
        10, 6, 7, 10, 7, 11,	
        12, 13, 14, 12, 14, 15,
        16, 17, 18, 16, 18, 19,
        20, 21, 22, 20, 22, 23
    };

    //Basic cube faces point numbers
    private static int[][] faceTriangleSource = {
        new int[] {0, 1, 2, 3},
        new int[] {4, 5, 6, 7},
        new int[] {2, 3, 4, 5},
        new int[] {6, 0, 1, 7},
        new int[] {1, 3, 5, 7},
        new int[] {6, 4, 2, 0}
    };

    //Basic cube uv map
    private Vector2[] uvSource = new Vector2[]{
        new Vector2(0,0),new Vector2(1,0),new Vector2(0,1),new Vector2(1,1),
        new Vector2(0,1),new Vector2(1,1),new Vector2(0,1),new Vector2(1,1),
        new Vector2(0,0),new Vector2(1,0),new Vector2(0,0),new Vector2(1,0),
        new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0),
        new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0),
        new Vector2(0,0),new Vector2(0,1),new Vector2(1,1),new Vector2(1,0)
    };

    public static bool isLevelStart = false;
    public static int pointLength;

    public Vector3[] createPoints;
    
    public int distanceY;
    public int distanceZ;

    public float railingLength;

    private bool isFinish = false;
    private bool isStart = false;
    

    public GameObject planeObject;
    
    public static int cubeNumber = 0;

    EnemyCreator enemyCreator;

    private void Awake() {
        
    }

    // Start is called before the first frame update
    private void Start() {
        isLevelStart = false;
        pointLength = createPoints.Length;
        cubeNumber = 0;
        SmoothPathStart();
        enemyCreator = this.GetComponentInChildren<EnemyCreator>();
    }

    public void CreateCube() {
        pointsCreate();
    }

    public void pointsCreate() {
        var createObject = Instantiate(planeObject,createPoints[cubeNumber],Quaternion.identity);
        Mesh planeMesh = createObject.GetComponent<MeshFilter>().mesh;

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        
        Vector3[] pointVectors = new Vector3[] {
            new Vector3(createPoints[cubeNumber+1].x - createPoints[cubeNumber].x,(-distanceY/2f) + createPoints[cubeNumber+1].y - createPoints[cubeNumber].y,(distanceZ/2f) + createPoints[cubeNumber+1].z - createPoints[cubeNumber].z),
            new Vector3(0,-distanceY/2f,distanceZ/2f),
            new Vector3(createPoints[cubeNumber+1].x - createPoints[cubeNumber].x,(distanceY/2f) + createPoints[cubeNumber+1].y - createPoints[cubeNumber].y,(distanceZ/2f) + createPoints[cubeNumber+1].z - createPoints[cubeNumber].z),
            new Vector3(0,distanceY/2f,distanceZ/2f),
            new Vector3(createPoints[cubeNumber+1].x - createPoints[cubeNumber].x,(distanceY/2f) + createPoints[cubeNumber+1].y - createPoints[cubeNumber].y,(-distanceZ/2f) + createPoints[cubeNumber+1].z - createPoints[cubeNumber].z),
            new Vector3(0,distanceY/2f,-distanceZ/2f),
            new Vector3(createPoints[cubeNumber+1].x - createPoints[cubeNumber].x,(-distanceY/2f) + createPoints[cubeNumber+1].y - createPoints[cubeNumber].y,(-distanceZ/2f) + createPoints[cubeNumber+1].z - createPoints[cubeNumber].z),
            new Vector3(0,-distanceY/2f,-distanceZ/2f)
        };
        
        VerticesCreate(vertices,triangles,pointVectors,planeMesh,createObject);
        
        //UpdateMesh(vertices,triangles,planeMesh,createObject);
    }

    // Update is called once per frame
    private void Update() {
        if (PlayerDollyCart.playerDolly.m_Position > 1 && !isStart) {
            PlayerDollyCart.playerDolly.m_Speed = 0;
        }
        if(PlayerDollyCart.playerDolly.m_Position > 2f) {
            BowShot.shotStart = true;
            LevelState.levelMapState = PlayerDollyCart.playerDolly.m_Position;
        }

        if(PlayerDollyCart.playerDolly.m_Position + 6 > cubeNumber) {
            if(cubeNumber != createPoints.Length-2 ) {
                if(createPoints[cubeNumber].y > -65 && createPoints[cubeNumber + 1].y > -65){
                    CreateCube();
                    CreateRailing();
                    enemyCreator.CreateEnemy();
                }
                cubeNumber++;
            }
            else if(!isFinish && cubeNumber == createPoints.Length-2) {
                isFinish = !isFinish;
                var decor =Instantiate(decorationObject,createPoints[cubeNumber],Quaternion.identity);
                decor.GetComponent<PlaneCreateAnim>().destroy = true;
                CreateCube();
            }
        }
        if(isLevelStart) {
            isStart = !isStart;
            PlayerDollyCart.playerDolly.m_Speed = PlayerProperty.speed;
        }
    }


    public void VerticesCreate(List<Vector3> vertices, List<int> triangles, Vector3[] pointVectors, Mesh planeMesh,GameObject boxObject) {    
        for (int i = 0; i < 6; i++){
            for (int k = 0; k < 4; k++) {
                vertices.Add(pointVectors[faceTriangleSource[i][k]]);
            }
        }
        FaceUp(vertices,triangles,planeMesh,boxObject);
    }

    public void FaceUp(List<Vector3> vertices, List<int> triangles, Mesh planeMesh,GameObject boxObject) {
        int vCount = vertices.Count;
        for(int i = 0 ; i < vCount*3/2; i++) {
            triangles.Add(trianglesSource[i]);
        }
        UpdateMesh(vertices,triangles,planeMesh,boxObject);
    }

    void UpdateMesh(List<Vector3> vertices, List<int> triangles, Mesh planeMesh,GameObject boxObject) {
        planeMesh.Clear();
        planeMesh.vertices = vertices.ToArray();
        planeMesh.triangles = triangles.ToArray();
        planeMesh.uv = uvSource;
        planeMesh.Optimize ();
		planeMesh.RecalculateNormals ();
        
        //boxObject.layer = LayerMask.NameToLayer("Ground");
        MeshCollider meshCollider = boxObject.AddComponent<MeshCollider>() as MeshCollider;
        meshCollider.convex = true ;
    }


    public void CreateRailing() {
        var railingObject1 = Instantiate(railingObject,createPoints[cubeNumber]+new Vector3(0,(distanceY/2f),((distanceZ/2f) - (railingLength/2))),Quaternion.identity);
        var railingObject2 = Instantiate(railingObject,createPoints[cubeNumber]+new Vector3(0,(distanceY/2f),(-(distanceZ/2f) + (railingLength/2))),Quaternion.identity);

        Mesh railingMesh1 = railingObject1.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices1 = railingMesh1.vertices;
        Mesh railingMesh2 = railingObject2.GetComponent<MeshFilter>().mesh;
        Vector3[] vertices2 = railingMesh2.vertices;

        RailingMeshEdit(vertices1);
        RailingMeshEdit(vertices2);

        RailingMeshUpdate(railingMesh1,vertices1);
        RailingMeshUpdate(railingMesh2,vertices2);
    }

    public void RailingMeshEdit(Vector3[] vertices) {
        for (int i = 0; i < vertices.Length; i++) {
            vertices[i] = new Vector3(vertices[i].x,vertices[i].y + (createPoints[cubeNumber+1].y - createPoints[cubeNumber].y)/(createPoints[cubeNumber+1].x - createPoints[cubeNumber].x)*vertices[i].x,vertices[i].z + (createPoints[cubeNumber+1].z - createPoints[cubeNumber].z)/(createPoints[cubeNumber+1].x - createPoints[cubeNumber].x)*vertices[i].x);
        }
    }

    public void RailingMeshUpdate(Mesh railingMesh,Vector3[] vertices) {
        railingMesh.vertices = vertices;
        railingMesh.Optimize ();
		railingMesh.RecalculateNormals ();
    }


    public void LevelStart(){
        isLevelStart = true;
    }

    public void SmoothPathStart(){
        PlayerSmoothPath.playerSmoothPath.m_Waypoints = new CinemachineSmoothPath.Waypoint[createPoints.Length+2];
        PlayerSmoothPath.playerSmoothPath.m_Waypoints[0].position = new Vector3(-2,-6.5f,0);
        PlayerSmoothPath.playerSmoothPath.m_Waypoints[1].position = new Vector3(-1.5f,-1.5f,0);
        PlayerSmoothPath.playerSmoothPath.m_Waypoints[2].position = new Vector3(-2,3,0);
        PlayerSmoothPath.playerSmoothPath.m_Waypoints[0].roll = -810;
        PlayerSmoothPath.playerSmoothPath.m_Waypoints[1].roll = -90;
        PlayerSmoothPath.playerSmoothPath.m_Waypoints[2].roll = -90;
        for (int i = 3; i < createPoints.Length+2; i++) {
            if(createPoints[i-2].y > -65){
                PlayerSmoothPath.playerSmoothPath.m_Waypoints[i].position = createPoints[i-2] + new Vector3(0,(distanceY/1.5f)+1f,0);
            }
            else{
                PlayerSmoothPath.playerSmoothPath.m_Waypoints[i].position = createPoints[i-2] + (Vector3.up*100);
            }
            
            if(i == createPoints.Length+1) {
                PlayerSmoothPath.playerSmoothPath.m_Waypoints[i].position += new Vector3(0,1.75f,0);
                PlayerSmoothPath.playerSmoothPath.m_Waypoints[i].roll = +720;
            }
        }
    }

}