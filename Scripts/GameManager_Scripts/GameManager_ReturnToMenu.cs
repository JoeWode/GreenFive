using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_ReturnToMenu : MonoBehaviour {
    	
    	private GameManager_Master gameManagerMaster;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.ReturnToMainMenuEvent += ReturnToMenu;
    	}
    	
    	void OnDisable() 
    	{
    	    gameManagerMaster.ReturnToMainMenuEvent -= ReturnToMenu;
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void ReturnToMenu()
    	{
    	    Application.LoadLevel(0);
    	}
    }
}

