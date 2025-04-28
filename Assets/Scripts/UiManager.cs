using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UiManager : MonoBehaviour{
    
    private Text scoreText ;
    private GameManager gameManager ;
    void Start(){
        gameManager = FindAnyObjectByType<GameManager>();
        scoreText = transform.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update(){
        scoreText.text = gameManager.score.ToString() ;
    }
}
