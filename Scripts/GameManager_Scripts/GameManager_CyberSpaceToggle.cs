using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_CyberSpaceToggle : MonoBehaviour 
    {
    	
    	private GameManager_Master gameManagerMaster;
    	public GameObject player;
    	public GameObject playerCyberspace;
    	public bool canHack;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.CyberSpaceToggleEvent += ToggleCyberSpace;
    	}
    	
    	void OnDisable()
    	{
    	    gameManagerMaster.CyberSpaceToggleEvent += ToggleCyberSpace;
    	}
    	
    	void Update() 
    	{
    	    CheckForCyberSpaceToggleRequest();
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void CheckForCyberSpaceToggleRequest()
    	{
    	    if(!gameManagerMaster.isMenuOn && !gameManagerMaster.isGameOver && canHack && Input.GetButtonUp("Use"))
    	    {
    	        ToggleCyberSpace();
    	    }
    	}
    	
    	void ToggleCyberSpace()
    	{
    	    if(player != null && playerCyberspace != null)
    	    {
    	        player.SetActive(!player.activeSelf);
    	        playerCyberspace.SetActive(!playerCyberspace.activeSelf);
    	    }
    	}
    }
}

