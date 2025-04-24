using UnityEngine;

public class PlayerController : MonoBehaviour{
    
    private float HorizontalAxis ;
    private Rigidbody playerRb ;
    private Vector3 playerPos ;
    public float speed ;
    
    void Start(){
        playerRb = GetComponent<Rigidbody>();
    }

    void Update(){
        HorizontalAxis = Input.GetAxis("Horizontal");
        playerPos = playerRb.position ;
        playerRb.position += Vector3.right * HorizontalAxis * Time.deltaTime * speed;
        if(playerPos.x < -7) {
            playerRb.position = new Vector3(-7,playerPos.y,playerPos.z);
        }else if(playerPos.x >7){
            playerRb.position = new Vector3(7,playerPos.y,playerPos.z);

        }
        
    }
}
