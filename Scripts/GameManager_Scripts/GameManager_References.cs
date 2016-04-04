using UnityEngine;
using System.Collections;

namespace G5
{
    public class GameManager_References : MonoBehaviour {
    
    	public string playerTag;
    	public static string _playerTag;
    	public string enemyTag;
    	public static string _enemyTag;
    	public string npcTag;
    	public string _npcTag;
    	public static GameObject _player;
    	
    	void OnEnable() 
    	{
    	    _playerTag = playerTag;
    	    _enemyTag = enemyTag;
    	    _npcTag = npcTag;
    	    _player = GameObject.FindGameObjectWithTag(_playerTag);
    	}
    }
}

