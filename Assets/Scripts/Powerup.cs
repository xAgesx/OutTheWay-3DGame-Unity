using UnityEngine;

public class Powerup : MonoBehaviour{
    
    private Rigidbody powerupRb ;
    private Collider powerupCollider ;
    public float speed ;
    void Start(){
        powerupRb = GetComponent<Rigidbody>();
        powerupCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update(){
        
        powerupRb.AddForce( new Vector3(0,0,-speed)*Time.deltaTime)  ;
    }

}
