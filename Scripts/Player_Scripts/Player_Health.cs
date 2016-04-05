using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace G5
{
    public class Player_Health : MonoBehaviour 
    {
    	
    	private Player_Master playerMaster;
    	private GameManager_Master gameManagerMaster;
    	public int playerHealth;
    	public Text healthText;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    SetUI();
    	    playerMaster.EventPlayerHealthDeduction += DeductHealth;
    	    playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
    	}
    	

    	void onDisable() 
    	{
    	    playerMaster.EventPlayerHealthDeduction -= DeductHealth;
    	    playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
    	    playerMaster = GetComponent<Player_Master>();
    	}
    	
    	void DeductHealth(int healthChange)
    	{
    	    playerHealth -= healthChange;
    	    
    	    if(playerHealth <= 0)
    	    {
    	        playerHealth = 0;
    	        gameManagerMaster.CallEventGameOver();
    	    }
    	    SetUI();
    	}
    	
    	void IncreaseHealth(int healthChange)
    	{
    	    playerHealth += healthChange;
	        	    
	    if(playerHealth > 100)
	    {
	        playerHealth = 100;
	    }
    	    SetUI();
    	}
    	
    	void SetUI()
    	{
    	    if(healthText != null)
    	    {
    	        healthText.text = playerHealth.ToString();
    	    }
    	}
    }
}
