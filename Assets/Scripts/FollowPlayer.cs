using UnityEngine;

public class FollowPlayer : MonoBehaviour{
    
    private GameObject player ;
    public float offset = 0 ;
    void Start(){
        player = GameObject.Find("Player");
    }

    void Update(){
        transform.position = new Vector3(player.transform.position.x,transform.position.y, offset) ;
    }
    
}
