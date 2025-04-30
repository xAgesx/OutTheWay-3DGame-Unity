using UnityEngine;

public class Destroyer : MonoBehaviour{

    private GameManager gameManager ;

    void Start(){
        gameManager = FindAnyObjectByType<GameManager>();
    }
    void OnCollisionEnter(Collision collision){
        
        if(collision.gameObject.CompareTag("Obstacle")){
            Destroy(collision.gameObject);
            gameManager.score ++ ; 
        }else if(collision.gameObject.CompareTag("Powerup")){
            Destroy(collision.gameObject);
        }
       
    }

}
