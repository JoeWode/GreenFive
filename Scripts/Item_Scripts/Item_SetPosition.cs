using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_SetPosition : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public Vector3 itemLocalPosition;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    SetPositionOnPlayer();
    	    itemMaster.EventObjectPickup += SetPositionOnPlayer;
    	}

    	void OnDisable() 
    	{
    	    itemMaster.EventObjectPickup -= SetPositionOnPlayer;
    	}
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
    	}
    	
    	void SetPositionOnPlayer()
    	{
    	    if(transform.root.CompareTag(GameManager_References._playerTag))
    	    {
    	        transform.localPosition = itemLocalPosition;
    	    }
    	}
    }
}

