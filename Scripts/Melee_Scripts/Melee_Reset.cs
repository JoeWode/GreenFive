using UnityEngine;
using System.Collections;

namespace G5
{
	public class Melee_Reset : MonoBehaviour 
	{

		private Melee_Master meleeMaster;
		private Item_Master itemMaster;

		void OnEnable()
		{
			SetInitialReferences();
			
			if(itemMaster != null)
			{
				itemMaster.EventObjectThrow += ResetMelee;
			}
		}

		void OnDisable()
		{
			if(itemMaster != null)
			{
				itemMaster.EventObjectThrow -= ResetMelee;
			}
		}

		void SetInitialReferences()
		{
			meleeMaster = GetComponent<Melee_Master>();
			
			if(GetComponent<Item_Master>() != null)
			{
				itemMaster = GetComponent<Item_Master>();
			}
		}
		
		void ResetMelee()
		{
			meleeMaster.isInUse = false;
		}
    }
}

