using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Colliders : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	public Collider[] colliders;
    	public PhysicMaterial myPhysicMaterial;
    	private string playerTag;
    	
    	void OnEnable() 
    	{
    	    SetInitialReferences();
    	    CheckIfStartsInInventory();
    	    itemMaster.EventObjectThrow += EnableColliders;
    	    itemMaster.EventObjectPickup += DisableColliders;
    	}

    	void OnDisable() 
    	{
    	    itemMaster.EventObjectThrow -= EnableColliders;
    	    itemMaster.EventObjectPickup -= DisableColliders;
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
    	
    	void CheckIfStartsInInventory()
    	{
    	    if(transform.root.CompareTag(playerTag))
    	    {
    	        DisableColliders();
    	    }
    	}
    	
    	void EnableColliders()
    	{
    	    if(colliders.Length > 0)
    	    {
    	        foreach(Collider col in colliders)
    	        {
    	            col.enabled = true;
    	            
    	            if(myPhysicMaterial != null)
    	            {
    	                col.material = myPhysicMaterial;
    	            }
    	        }
    	    }
    	}
    	
    	void DisableColliders()
    	{
    	    if(colliders.Length > 0)
	    {
	        foreach(Collider col in colliders)
	        {
	            col.enabled = false;
	        }
    	    }
    	}
    	
    }
}

