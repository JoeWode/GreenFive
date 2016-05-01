using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace G5
{
    public class GameManager_RestartLevel : MonoBehaviour {
    
    	private GameManager_Master gameManagerMaster;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    gameManagerMaster.RestartLevelEvent += RestartLevel;
    	}
    	
    	void OnDisable() 
    	{
    	    gameManagerMaster.RestartLevelEvent -= RestartLevel;
    	}
    	
    	void SetInitialReferences()
    	{
    	    gameManagerMaster = GetComponent<GameManager_Master>();
    	}
    	
    	void RestartLevel()
    	{
    	    //Application.LoadLevel(Application.loadedLevel);
    	    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    	}
    }
}
