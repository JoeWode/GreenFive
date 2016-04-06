using UnityEngine;
using System.Collections;

namespace G5
{
    public class Player_DetectItem : MonoBehaviour 
    {
    
    	[Tooltip("Enter the layer being used for items.")]
    	public LayerMask layerToDetect;
    	[Tooltip("Which transform will the ray originate from?")]
    	public Transform rayTransformPivot;
    	[Tooltip("Enter the input manager reference for the item pickup key.")]
    	public string pickupButton;
    	
    	private Transform itemAvailableForPickup;
    	private RaycastHit hit;
    	private float detectRange = 3.0f;
    	private float detectRadius = 0.7f;
    	private bool itemInRange;
    	
    	private float labelWidth = 200;
    	private float labelHeight = 50;
    	
    	void Update() 
    	{
    	    CastRayForDetectingItems();
    	    CheckForItemPickupAttempt();
    	}
    	
    	void CastRayForDetectingItems()
    	{
    	    if(Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
    	    {
    	        itemAvailableForPickup = hit.transform;
    	        itemInRange = true;
    	    }
    	    else
    	    {
    	        itemInRange = false;
    	    }
    	}
    	
    	void CheckForItemPickupAttempt()
    	{
    	    if(Input.GetButtonDown(pickupButton) && Time.timeScale > 0 && itemInRange && itemAvailableForPickup.root.tag != GameManager_References._playerTag)
    	    {
    	        itemAvailableForPickup.GetComponent<Item_Master>().CallEventPickupAction(rayTransformPivot);
    	    }
    	}
    	
    	void OnGUI()
    	{
    	    if(itemInRange && itemAvailableForPickup != null)
    	    {
    	        GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight), itemAvailableForPickup.name);
    	    }
    	}
    }
}

