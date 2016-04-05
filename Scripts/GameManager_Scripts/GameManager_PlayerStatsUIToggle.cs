using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_PlayerStatsUIToggle : MonoBehaviour {
    
    	[Tooltip("Does this game have a player information window?")]
    	public bool hasStats;
    	private GameManager_Master gameManagerMaster;
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
    	    
    	    if(togglePlayerStatsButton == "")
	    {
	        Debug.LogWarning("Please type in the input manager reference to the inventory key in the 'toggle player stats button' field.");
	        this.enabled = false;
    	    }
    	}
    	
    	void CheckForPlayerStatsToggleRequest()
    	{
    	    if(Input.GetButtonUp(togglePlayerStatsButton) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasStats)
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
    	    }
    	}
    }
}

