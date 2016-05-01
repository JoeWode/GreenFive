using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_SetLayer : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public string itemThrowLayer;
    	public string itemPickupLayer;
    	private string playerTag;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    SetLayerOnEnable();
    	    itemMaster.EventObjectPickup += SetItemToPickupLayer;
    	    itemMaster.EventObjectThrow += SetItemToThrowLayer;
    	}
    	
    	void OnDisable() 
    	{
    	    itemMaster.EventObjectPickup -= SetItemToPickupLayer;
    	    itemMaster.EventObjectThrow -= SetItemToThrowLayer;
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
    	
    	void SetItemToThrowLayer()
    	{
    	    SetLayer(transform, itemThrowLayer);
    	}
    	
    	void SetItemToPickupLayer()
    	{
    	    SetLayer(transform, itemPickupLayer);
    	}
    	
    	void SetLayerOnEnable()
    	{
    	    if(itemPickupLayer == "")
    	    {
    	        itemPickupLayer = "Item";
    	    }
    	    
    	    if(itemThrowLayer == "")
    	    {
    	        itemThrowLayer = "Item";
    	    }
    	    
    	    if(transform.root.CompareTag(playerTag))
    	    {
    	        SetItemToPickupLayer();
    	    }
    	    else
    	    {
    	        SetItemToThrowLayer();
    	    }
    	}
    	
    	void SetLayer(Transform tForm, string itemLayerName)
    	{
    	    tForm.gameObject.layer = LayerMask.NameToLayer(itemLayerName);
    	    
    	    foreach(Transform child in tForm)
    	    {
    	        SetLayer(child, itemLayerName);
    	    }
    	}
    }
}

