using System.Threading.Tasks;
using UnityEngine;

public class Powerup : MonoBehaviour{
    
    private Rigidbody powerupRb ;
    private Collider powerupCollider ;
    public float speed ;
    public string powerupType ;
    public GameObject activeShieldPrefab ;
    GameObject activeShield;
    void Start(){
        powerupRb = GetComponent<Rigidbody>();
        powerupCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update(){
        
        powerupRb.AddForce( new Vector3(0,0,-speed)*Time.deltaTime)  ;
        if(powerupRb.transform.position.y <= 3){
            speed = 100 ;
        }
    }
    public void Activate(GameObject player){
        switch (powerupType){
            case "Shield" : ActivateShield(player);break;
            case "SlowMotion" : Debug.Log("SlowMotion");break;
            default : Debug.Log("Nothing");break;

        }
        
    }
    async void ActivateShield(GameObject player){

        activeShield = Instantiate(activeShieldPrefab,player.transform.position + new Vector3(0,2,1),Quaternion.Euler(new Vector3(0,180,0)));
        await Task.Delay(3000);
        DeactivateShield();
        
    }
    void DeactivateShield(){
        
        Destroy(activeShield);
    }
    

}
