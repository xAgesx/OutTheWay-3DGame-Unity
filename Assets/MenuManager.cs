using UnityEngine;
using UnityEngine.SceneManagement ;

public class MenuManager : MonoBehaviour{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
    }

    // Update is called once per frame
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }
    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
