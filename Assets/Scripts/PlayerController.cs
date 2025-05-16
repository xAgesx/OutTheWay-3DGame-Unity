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
       //Use Powerup
        if(Input.GetButtonDown("Jump") && Powerup.obtainedPowerups.Count > 0 && !Powerup.powerupActive){
            Powerup.obtainedPowerups[0].GetComponent<Powerup>().Activate(this.gameObject);
        }
        //Pause
        if(Input.GetButtonDown("Cancel")){
            GameObject.Find("GameManager").GetComponent<GameManager>().Pause();
        }
        
    }
    void OnCollisionEnter(Collision collision){
        Powerup powerupScript = collision.transform.GetComponent<Powerup>();
        if(collision.gameObject.CompareTag("Powerup")){
            
            if(Powerup.obtainedPowerups.Count < 3 ){
                powerupScript.ObtainPowerup(collision.gameObject);
                collision.gameObject.GetComponent<Collider>().enabled = false;
                collision.gameObject.GetComponent<MeshRenderer>().enabled = false;
                Debug.Log(Powerup.obtainedPowerups.Count);
                
            }else{
                Destroy(collision.gameObject);
            }
             
            
        }else if(collision.gameObject.CompareTag("Obstacle")){
            Powerup.obtainedPowerups.Clear();
            Invoke("Restart",1f);
            
            
        }
    }
    void Restart(){
        GameObject.Find("GameManager").GetComponent<GameManager>().Restart();
    }
}
