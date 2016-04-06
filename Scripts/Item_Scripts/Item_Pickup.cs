using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Pickup : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    itemMaster.EventPickupAction += CarryOutPickupActions;
    	}

    	void OnDisable() 
    	{
    	    itemMaster.EventPickupAction -= CarryOutPickupActions;
    	}
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
    	}
    	
    	void CarryOutPickupActions(Transform tParent)
    	{
    	    transform.SetParent(tParent);
    	    itemMaster.CallEventObjectPickup();
    	    transform.gameObject.SetActive(false);
    	}
    }
}

