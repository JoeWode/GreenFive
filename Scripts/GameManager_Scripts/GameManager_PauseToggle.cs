using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_PauseToggle : MonoBehaviour 
    {
    
    	private GameManager_Master gameManagerMaster;
    	private bool isPaused;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.MenuToggleEvent += TogglePause;
    	    gameManagerMaster.InventoryUIToggleEvent += TogglePause;
    	    gameManagerMaster.PlayerStatsUIToggleEvent += TogglePause;
    	}
    	
    	void OnDisable() 
    	{
    	    gameManagerMaster.MenuToggleEvent -= TogglePause;
    	    gameManagerMaster.InventoryUIToggleEvent -= TogglePause;
    	    gameManagerMaster.PlayerStatsUIToggleEvent -= TogglePause;
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void TogglePause()
    	{
    	    if(isPaused)
    	    {
    	        Time.timeScale = 1;
    	        isPaused = false;
    	    } 
    	    else
    	    {
    	       Time.timeScale = 0;
    	       isPaused = true;
    	    }
    	}
    }
}

