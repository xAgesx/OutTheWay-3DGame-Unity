using UnityEngine;

public class PlayerController : MonoBehaviour{
    
    private float HorizontalAxis ;
    private Rigidbody playerRb ;
    private Vector3 playerPos ;
    public float speed ;
    public Animator animator ;
    
    void Start(){
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update(){
        HorizontalAxis = Input.GetAxis("Horizontal");
        if(HorizontalAxis != 0 ){
            animator.SetBool("Run",true);
        }else{
            animator.SetBool("Run",false);
        }
        playerPos = playerRb.position ;
        playerRb.position += Vector3.right * HorizontalAxis * Time.deltaTime * speed;
        //Rotate the player based on the horizontal AXIS : -1 <= axis <= 1 so we multiply it buy 1.999 to always get and int that within those margins
        playerRb.rotation = Quaternion.Euler(new Vector3(0,(int)(HorizontalAxis*1.999)*90,0));
        if(playerPos.x < -7) {
            playerRb.position = new Vector3(-7,playerPos.y,playerPos.z);
        }else if(playerPos.x >7){
            playerRb.position = new Vector3(7,playerPos.y,playerPos.z);

        }
        
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Powerup")){
            Destroy(collision.gameObject);
        }
    }
}
