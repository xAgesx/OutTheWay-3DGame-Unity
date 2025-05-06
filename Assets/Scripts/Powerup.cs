using System.Threading.Tasks;
using UnityEngine;
using System.Collections.Generic;
using System;

public class Powerup : MonoBehaviour{
    
    private Rigidbody powerupRb ;
    private Collider powerupCollider ;
    public float speed ;
    public string powerupType ;
    public GameObject activeShieldPrefab ;
    public GameObject player ;
    GameObject activeShield;
    [SerializeField]
    public static List<GameObject> obtainedPowerups = new List<GameObject>(); 
    public static Boolean powerupActive ;

    void Start(){
        powerupActive = false;
        powerupRb = GetComponent<Rigidbody>();
        powerupCollider = GetComponent<Collider>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){
        
        powerupRb.AddForce( new Vector3(0,0,-speed)*Time.deltaTime)  ;
        if(powerupRb.transform.position.y <= 3){
            speed = 100 ;
        }
    }
    public void Activate(GameObject player){
        powerupActive = true;
        switch (obtainedPowerups[0].GetComponent<Powerup>().powerupType){
            case "Shield" : ActivateShield(player);break;
            case "SlowMotion" : Debug.Log("SlowMotion");ActivateSlowMotion();break;
            default : Debug.Log("Nothing");break;

        }
        obtainedPowerups.RemoveAt(0);
        
    }
    async void ActivateShield(GameObject player){
    
        activeShield = Instantiate(activeShieldPrefab,player.transform.position + new Vector3(0,1,1),Quaternion.Euler(new Vector3(0,180,0)));
        await Task.Delay(3000);
        DeactivateShield();
        
        
    }
    void DeactivateShield(){
        
        Destroy(activeShield);
        powerupActive = false;
    }
    public void ObtainPowerup(GameObject type){
            obtainedPowerups.Add(type);
            Debug.Log("added");
            Debug.Log(string.Join(", ", obtainedPowerups));
        
    }
    async void ActivateSlowMotion(){
        PlayerController playerController = player.GetComponent<PlayerController>();
        Animator playerAnim = player.GetComponent<Animator>();
        
        //Activate Slowmo
        Time.timeScale = 0.2f;
        playerController.speed *= 4 ;
        playerAnim.speed = 4 ;
        
        //Deactivate after delay
        await Task.Delay(2000);
        Time.timeScale = 1f;
        playerController.speed /= 4 ;
        playerAnim.speed = 1 ;
        powerupActive = false;
        
    }
    

}
