using UnityEngine;

public class snowBall : MonoBehaviour{
    
    public Vector3 offset ;
    private float sizeScale;
    void Start(){
        //set a random size to the snowball
        sizeScale = Random.Range(0.3f,1f);
        GetComponent<Rigidbody>().AddForce(0,0,Random.Range(0,100));
        transform.localScale = new Vector3(sizeScale,sizeScale,sizeScale);
    }

    void Update(){
        //Make the snowBall grow slowly with time 
        ScaleUp();
        
    }
    public void ScaleUp(){
        transform.localScale += offset * Time.deltaTime * 100;

    }
}
