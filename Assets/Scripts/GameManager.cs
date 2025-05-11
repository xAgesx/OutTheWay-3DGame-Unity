using UnityEngine;
using System.Collections ;
using UnityEngine.SceneManagement ;
using UnityEditor.Build.Content;
using System;

public class GameManager : MonoBehaviour{
    
    public int score ;
    public Spawner spawner;
    [SerializeField]
    private int lastTriggeredFlag ;

    public GameObject pauseUI ;
    public GameObject scoreUI;
    Boolean pauseOn = false ;
    void Start(){
        score = 0 ;
        lastTriggeredFlag = 0;
    }

public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void GameOver(){
        Debug.Log("Game Over !");
        Invoke("Restart",1f);
        
    }

    public void Restart(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1 ;
    }
   
    
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }
    public void Pause(){
        if(!pauseOn){
            Debug.Log("Pause");
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            pauseOn = true;
            scoreUI.SetActive(false);
        }else{
            Resume();
        }
        
        
        
    }
    public void Resume(){
//Disable All UIs
        Debug.Log("Resume");
        pauseUI.SetActive(false);
        pauseOn = false;
//Reset TimeFlow + Enable Score Ui
        Time.timeScale = 1;
        
        scoreUI.SetActive(true);
        

    }
    void Update(){
        if(spawner.spawnTimer < 0.5f){
            spawner.spawnTimer  = 0.2f;
        }else if(score >= lastTriggeredFlag + 30){
            lastTriggeredFlag = score  ;
            spawner.spawnTimer -= 0.5f;
        }

        
    }
}
