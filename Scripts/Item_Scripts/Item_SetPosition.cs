using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_SetPosition : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public Vector3 itemLocalPosition;
    	private string playerTag;
    	
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
    	
    	void Start()
    	{
    	    SetInitialReferences();
    	    Invoke("SetInitialReferences", 0.001f);
    	}
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
    	    playerTag = "Player";
    	}
    	
    	void SetPositionOnPlayer()
    	{
    	    if(transform.root.CompareTag(playerTag))
    	    {
    	        transform.localPosition = itemLocalPosition;
    	    }
    	}
    }
}

