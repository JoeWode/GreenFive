using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour 
    {
    	
    	[Tooltip("Does this game have an inventory?")]
    	public bool hasInventory;
    	public GameObject inventoryUI;
    	public string toggleInventoryButton;
    	private GameManager_Master gameManagerMaster;
    	
    	void Start() 
    	{
    	    SetInitialReferences();
    	}
    	
    	void Update() 
    	{
    	    CheckForInventoryToggleRequest();
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	    
    	    if(toggleInventoryButton == "")
    	    {
    	        Debug.LogWarning("Please type in the input manager reference to the inventory key in the 'toggle inventory button' field.");
    	        this.enabled = false;
    	    }
    	}
    	
    	void CheckForInventoryToggleRequest()
    	{
    	    if(Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && hasInventory)
    	    {
    	        ToggleInventoryUI();
    	    }
    	}
    	
    	void ToggleInventoryUI()
    	{
    	    if(inventoryUI != null)
    	    {
    	        inventoryUI.SetActive(!inventoryUI.activeSelf);
    	        gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
    	        gameManagerMaster.CallEventInventoryUIToggle();
    	    }
    	}
    }
}

