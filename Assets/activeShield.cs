using UnityEngine;

public class activeShield : MonoBehaviour{
    
    GameObject player ;
    void Start(){
        player = GameObject.Find("Player");   
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Obstacle")){
            Destroy(collision.gameObject);
        }    
        
    }
    
}
