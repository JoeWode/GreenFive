using UnityEngine;
using System.Collections;

namespace G5
{
	public class Melee_StandardInput : MonoBehaviour 
	{

		private Melee_Master meleeMaster;
		private Transform myTransform;
		private float nextSwing;
		public string attackButtonName;

		void Start() 
		{
			SetInitialReferences();
		}

		void Update() 
		{
			CheckIfWeaponShouldAttack();
		}

		void SetInitialReferences()
		{
			meleeMaster = GetComponent<Melee_Master>();
			myTransform = transform;
		}
		
		void CheckIfWeaponShouldAttack()
		{
			if(Time.timeScale > 0 && myTransform.root.CompareTag(GameManager_References._playerTag) && !meleeMaster.isInUse)
			{
				if(Input.GetButton(attackButtonName) && Time.time > nextSwing)
				{
					nextSwing = Time.time + meleeMaster.swingRate;
					meleeMaster.isInUse = true;
					meleeMaster.CallEventPlayerInput();
				}
			}
		}
    }
}

