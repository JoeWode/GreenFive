using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Animator : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public Animator myAnimator;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    itemMaster.EventObjectThrow += DisableMyAnimator;
    	    itemMaster.EventObjectPickup += EnableMyAnimator;
    	}

    	void OnDisable() 
    	{
    	    itemMaster.EventObjectThrow -= DisableMyAnimator;
    	    itemMaster.EventObjectPickup -= EnableMyAnimator;
    	}
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
    	}
    	
    	void EnableMyAnimator()
    	{
    	    if(myAnimator != null)
    	    {
    	        myAnimator.enabled = true;
    	    }
    	}
    	
    	void DisableMyAnimator()
    	{
    	    if(myAnimator != null)
	    {
	        myAnimator.enabled = false;
    	    }
    	}
    }
}

