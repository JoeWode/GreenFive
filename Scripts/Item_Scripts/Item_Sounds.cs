using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Sounds : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public float defaultVolume;
    	public AudioClip throwSound;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    itemMaster.EventObjectThrow += PlayThrowSound;
    	}
    	
    	void OnDisable() 
    	{
    	    itemMaster.EventObjectThrow -= PlayThrowSound;
    	}
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
    	}
    	
    	void PlayThrowSound()
    	{
    	    if(throwSound != null)
    	    {
    	        AudioSource.PlayClipAtPoint(throwSound, transform.position, defaultVolume);
    	    }
    	}
    }
}

