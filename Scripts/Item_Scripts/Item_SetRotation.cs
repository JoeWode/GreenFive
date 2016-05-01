using UnityEngine;
using System.Collections;

namespace G5
{
	public class Item_SetRotation : MonoBehaviour 
	{

		private Item_Master itemMaster;
		public Vector3 itemLocalRotation;

		void OnEnable()
		{
			SetInitialReferences();
			itemMaster.EventObjectPickup += SetRotationOnPlayer;
		}

		void OnDisable()
		{
			itemMaster.EventObjectPickup -= SetRotationOnPlayer;
		}

		void Start() 
		{
			SetRotationOnPlayer();
		}

		void SetInitialReferences()
		{
			itemMaster = GetComponent<Item_Master>();
		}
		
		void SetRotationOnPlayer()
		{
			if(transform.root.CompareTag("Player"))
			{
				transform.localEulerAngles = itemLocalRotation;
			}
		}
    }
}

