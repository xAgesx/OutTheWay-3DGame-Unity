using UnityEngine;

public class Spawner : MonoBehaviour{
    public GameObject snowBallPrefab ;
    private Vector3 spawnPos ;
    public float spawnTimer;
    public GameObject[] powerups ;
    
    void Start(){
        spawnTimer = 3f;
        InvokeRepeating("SpawnObstacle",1f,spawnTimer);
        InvokeRepeating("SpawnPowerup",3f,10f);
    }

    // Update is called once per frame
    void SpawnSnowBall(){

        spawnPos = new Vector3(Random.Range(-6,6),15,15);
        Instantiate(snowBallPrefab,spawnPos,transform.rotation);    
    }
    void SpawnObstacle(){
        int obstaclesNb = Random.Range(1,4);
        for(int j = 0 ; j<obstaclesNb ; j++){
            SpawnSnowBall();
        }
    }
    void SpawnPowerup(){
        spawnPos = new Vector3(Random.Range(-6,6),15,15);
        int powerupIndex = Random.Range(0,powerups.Length);
        Instantiate(powerups[powerupIndex],spawnPos,transform.rotation);
        
    }
}
