using UnityEngine;

public class Spawner : MonoBehaviour{
    public GameObject snowBallPrefab ;
    private Vector3 spawnPos ;
    public float spawnTimer;
    
    void Start(){
        spawnTimer = 3f;
        InvokeRepeating("SpawnObstacle",1f,spawnTimer);
    }

    // Update is called once per frame
    void SpawnSnowBall(){

        spawnPos = new Vector3(Random.Range(-7,7),15,15);
        Instantiate(snowBallPrefab,spawnPos,transform.rotation);
    }
    void SpawnObstacle(){
        int obstaclesNb = Random.Range(1,4);
        for(int j = 0 ; j<obstaclesNb ; j++){
            SpawnSnowBall();
        }
    }
}
