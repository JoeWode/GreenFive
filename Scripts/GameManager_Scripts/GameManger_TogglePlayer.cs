using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

namespace G5
{
    public class GameManger_TogglePlayer : MonoBehaviour {
    
    	public FirstPersonController playerController;
    	private GameManager_Master gameManagerMaster;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.MenuToggleEvent += TogglePlayerController;
    	    gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
    	    gameManagerMaster.PlayerStatsUIToggleEvent += TogglePlayerController;
    	}
    	
    	void OnDisable() 
    	{
    	    gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
    	    gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;
    	    gameManagerMaster.PlayerStatsUIToggleEvent -= TogglePlayerController;
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void TogglePlayerController()
    	{
    	    if(playerController != null)
    	    {
    	       playerController.enabled = !playerController.enabled; 
    	    }
    	}
    }
}

