using UnityEngine;
using System.Collections;

namespace G5
{
	public class Destructible_PlayerInventoryUpdate : MonoBehaviour 
	{

		private Destructible_Master destructibleMaster;
		private Player_Master playerMaster;

		void OnEnable()
		{
			SetInitialReferences();
			destructibleMaster.EventDestroyMe += ForcePlayerInventoryUpdate;
		}

		void OnDisable()
		{
			destructibleMaster.EventDestroyMe -= ForcePlayerInventoryUpdate;
		}

		void SetInitialReferences()
		{
			destructibleMaster = GetComponent<Destructible_Master>();
			
			playerMaster = GameObject.FindWithTag("Player").GetComponent<Player_Master>();
			
			if(GetComponent<Item_Master>() == null)
			{
				Destroy(this);
			}
		}
		
		void ForcePlayerInventoryUpdate()
		{
			if(playerMaster != null)
			{
				playerMaster.CallEventInventoryChanged();
			}
		}
    }
}

