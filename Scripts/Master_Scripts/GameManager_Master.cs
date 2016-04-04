using UnityEngine;
using System.Collections;


namespace G5
{
    public class GameManager_Master : MonoBehaviour 
    {
    
        public delegate void GameManagerEventHandler();
        public event GameManagerEventHandler MenuToggleEvent;
        public event GameManagerEventHandler PlayerStatsUIToggleEvent;
        public event GameManagerEventHandler InventoryUIToggleEvent;
        public event GameManagerEventHandler RestartLevelEvent;
        public event GameManagerEventHandler ReturnToMainMenuEvent;
        public event GameManagerEventHandler GameOverEvent;
        public event GameManagerEventHandler CyberSpaceToggleEvent;
        
        
        public bool isGameOver;
        public bool isInventoryUIOn;
        public bool isPlayerStatsUIOn;
        public bool isMenuOn;
    
    	public void CallEventMenuToggle() 
    	{
    	    if(MenuToggleEvent != null)
    	    {
    	        MenuToggleEvent();
    	    }
    	}
    	
    	public void CallEventPlayerStatsUIToggle() 
	{
	    if(PlayerStatsUIToggleEvent != null)
	    {
	        PlayerStatsUIToggleEvent();
	    }
    	}
    	
    	public void CallEventInventoryUIToggle() 
	{
	    if(InventoryUIToggleEvent != null)
	    {
	        InventoryUIToggleEvent();
	    }
    	}
    	
    	public void CallEventRestartLevel() 
	{
	    if(RestartLevelEvent != null)
	    {
	        RestartLevelEvent();
	    }
    	}
    	
    	public void CallEventReturnToMainMenu() 
	{
	    if(ReturnToMainMenuEvent != null)
	    {
		ReturnToMainMenuEvent();
	    }
    	}
    	
    	public void CallEventGameOver() 
	{
	    if(GameOverEvent != null)
	    {
		isGameOver = true;
		GameOverEvent();
	    }
    	}
    	
    	public void CallEventCyberspaceToggle() 
	{
	    if(CyberSpaceToggleEvent != null)
	    {
		CyberSpaceToggleEvent();
	    }
    	}
    	
    }
}

