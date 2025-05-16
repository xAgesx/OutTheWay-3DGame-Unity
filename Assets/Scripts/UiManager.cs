using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] powerupSlots; 
    public Sprite shieldSprite;
    public Sprite slowmoSprite;
    public Sprite defaultSprite;
    public Text scoreText ;
    public GameManager gameManager ;
    private List<GameObject> previousPowerups = new List<GameObject>();
    

    void Start(){
        Powerup.obtainedPowerups = new List<GameObject>() ;
    }
    void Update()
    {
        if (Powerup.obtainedPowerups.Count != previousPowerups.Count)
        {
            UpdatePowerupSlots();
            previousPowerups = new List<GameObject>(Powerup.obtainedPowerups);
        }
        scoreText.text = gameManager.score.ToString() ;
    }

    void UpdatePowerupSlots()
    {
        for (int i = 0; i < powerupSlots.Length; i++)
        {
            if (i < Powerup.obtainedPowerups.Count)
            {   
                if(Powerup.obtainedPowerups[i].GetComponent<Powerup>().powerupType == null){
                    break;
                }
                var type = Powerup.obtainedPowerups[i].GetComponent<Powerup>().powerupType;
                powerupSlots[i].enabled = true;

                switch (type)
                {
                    case "Shield":
                        powerupSlots[i].sprite = shieldSprite;
                        break;
                    case "SlowMotion":
                        powerupSlots[i].sprite = slowmoSprite;
                        break;
                    default:
                        powerupSlots[i].sprite = defaultSprite;
                        break;
                }
            }
            else
            {
                powerupSlots[i].sprite = defaultSprite;

            }
        }
    }
    
   
}
