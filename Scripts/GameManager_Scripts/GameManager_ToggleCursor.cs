using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_ToggleCursor : MonoBehaviour {
    
    	private GameManager_Master gameManagerMaster;
    	public bool isCursorLocked = true;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.MenuToggleEvent += ToggleCursor;
    	    gameManagerMaster.InventoryUIToggleEvent += ToggleCursor;
    	    gameManagerMaster.PlayerStatsUIToggleEvent += ToggleCursor;
    	}
    	
    	void OnDisable() 
    	{
    	    gameManagerMaster.MenuToggleEvent -= ToggleCursor;
    	    gameManagerMaster.InventoryUIToggleEvent -= ToggleCursor;
    	    gameManagerMaster.PlayerStatsUIToggleEvent -= ToggleCursor;
    	}
    	
    	void Update()
    	{
    	
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void ToggleCursor()
    	{
    	    isCursorLocked = !isCursorLocked;
    	}
    	
    	void CheckCursorLockState()
    	{
    	    if(isCursorLocked)
    	    {
    	        Cursor.lockState = CursorLockMode.Locked;
    	        Cursor.visible = false;
    	    }
    	    else
    	    {
    	        Cursor.lockState = CursorLockMode.None;
    	        Cursor.visible = true;
    	    }
    	}
    }
}

