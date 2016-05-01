using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_PlayerStatsUIToggle : MonoBehaviour {
    
    	[Tooltip("Does this game have a player information window?")]
    	public bool hasStats;
    	private GameManager_Master gameManagerMaster;
    	private Player_Inventory playerInventory;
    	public GameObject playerStatsUI;
    	public string togglePlayerStatsButton;
    	
    	void Start() 
    	{
    	    SetInitialPreferences();
    	}
    	
    	void Update() 
    	{
    	    CheckForPlayerStatsToggleRequest();
    	}
    	
    	void SetInitialPreferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	    playerInventory = GameObject.Find("FPSController_ALFDP").GetComponent<Player_Inventory>();
    	    
    	    if(togglePlayerStatsButton == "")
	    {
	        Debug.LogWarning("Please type in the input manager reference to the inventory key in the 'toggle player stats button' field.");
	        this.enabled = false;
    	    }
    	}
    	
    	void CheckForPlayerStatsToggleRequest()
    	{
    	    if(Input.GetButtonUp(togglePlayerStatsButton) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && !gameManagerMaster.isFungusRunning && hasStats)
	    {
	        TogglePlayerStatsUI();
    	    }
    	}
    	
    	void TogglePlayerStatsUI()
    	{
    	    if(playerStatsUI != null)
	    {
	        playerStatsUI.SetActive(!playerStatsUI.activeSelf);
	        gameManagerMaster.isPlayerStatsUIOn = !gameManagerMaster.isPlayerStatsUIOn;
	        gameManagerMaster.CallEventPlayerStatsUIToggle();
	        
	        if(gameManagerMaster.isPlayerStatsUIOn)
		{
		    playerInventory.DeactivateAllInventoryItems();
    	        }
    	    }
    	}
    }
}

