using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_GameOver : MonoBehaviour 
    {
    
    	private GameManager_Master gameManagerMaster;
    	public GameObject panelGameOver;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.GameOverEvent += GameOverPanelOn;
    	}
    	
    	void OnDisable() 
    	{
    	    gameManagerMaster.GameOverEvent -= GameOverPanelOn;
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void GameOverPanelOn()
    	{
    	    if(panelGameOver != null)
    	    {
    	        panelGameOver.SetActive(true);
    	    }
    	}
    }
}

