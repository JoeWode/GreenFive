using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_SetLayer : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public string itemThrowLayer;
    	public string itemPickupLayer;
    	
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
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
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
    	    
    	    if(transform.root.CompareTag(GameManager_References._playerTag))
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

