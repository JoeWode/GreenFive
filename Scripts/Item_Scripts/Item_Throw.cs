using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Throw : MonoBehaviour 
    {
    	
    	private Item_Master itemMaster;
    	private Transform myTransform;
    	private Rigidbody myRigidbody;
    	private Vector3 throwDirection;
    	
    	public bool canBeThrown;
    	public string throwButtonName;
    	public float throwForce;
    	
    	void Start() 
    	{
    	    SetInitialReferences();
    	}

    	void Update() 
    	{
    	    CheckForThrowInput();
    	}
    	
    	void SetInitialReferences()
    	{
    	    itemMaster = GetComponent<Item_Master>();
    	    myTransform = transform;
    	    myRigidbody = GetComponent<Rigidbody>();
    	}
    	
    	void CheckForThrowInput()
    	{
    	    if(throwButtonName != null)
    	    {
    	        if(Input.GetButtonDown(throwButtonName) && Time.timeScale > 0 &&
    	            canBeThrown && myTransform.root.CompareTag(GameManager_References._playerTag))
    	        {
    	            CarryOutThrowActions();
    	        }
    	    }
    	}
    	
    	void CarryOutThrowActions()
    	{
    	    throwDirection = myTransform.parent.forward;
    	    myTransform.parent = null;
    	    itemMaster.CallEventObjectThrow();
    	    ThrowItem();
    	}
    	
    	void ThrowItem()
    	{
    	    myRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
    	}
    	
    	
    }
}

