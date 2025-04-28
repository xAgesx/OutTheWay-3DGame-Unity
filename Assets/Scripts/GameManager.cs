using UnityEngine;

public class GameManager : MonoBehaviour{
    
    public int score ;
    public Spawner spawner;
    [SerializeField]
    private int lastTriggeredFlag ;
    void Start(){
        score = 0 ;
        lastTriggeredFlag = 0;
    }

    // Update is called once per frame
    void Update(){
        if(spawner.spawnTimer < 0.5f){
            spawner.spawnTimer  = 0.2f;
        }else if(score >= lastTriggeredFlag + 30){
            lastTriggeredFlag = score  ;
            spawner.spawnTimer -= 0.5f;
        }
    }
}
