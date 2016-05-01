using UnityEngine;
using System.Collections;

namespace G5
{
	public class Item_HealthPickup : MonoBehaviour 
	{

		public Player_Master playerMaster;
		private Item_Outline itemOutline;
		public int healthIncrease;
		private Transform myTransform;

		void OnEnable()
		{
			SetInitialReferences();
		}

		void Update() 
		{
			CheckForActivationRequest();
		}

		void SetInitialReferences()
		{
			itemOutline = GetComponent<Item_Outline>();
			myTransform = transform;
		}
		
		void CheckForActivationRequest()
		{
			if(Input.GetButtonUp("Use") && itemOutline.isActive)
			{
				HealPlayer();
	    	}
	    	else if(Input.GetButtonUp("Use") && myTransform.parent != null)
	    	{
	    		HealPlayer();
	    	}
		}
		
		void HealPlayer()
		{
			if(myTransform.parent != null)
			{
				myTransform.parent = null;
				playerMaster.CallEventInventoryChanged();
				playerMaster.CallEventPlayerHealthIncrease(healthIncrease);
				Destroy(gameObject);
			}
			else
			{
				playerMaster.CallEventPlayerHealthIncrease(healthIncrease);
				Destroy(gameObject);
			}
		}
    }
}

