using UnityEngine;
using System.Collections;

namespace G5
{
	public class Melee_Swing : MonoBehaviour 
	{

		private Melee_Master meleeMaster;
		public Collider myCollider;
		public Rigidbody myRigidbody;
		public Animator myAnimator;

		void OnEnable()
		{
			SetInitialReferences();
			meleeMaster.EventPlayerInput += MeleeAttackActions;
		}

		void OnDisable()
		{
			meleeMaster.EventPlayerInput -= MeleeAttackActions;
		}

		void SetInitialReferences()
		{
			meleeMaster = GetComponent<Melee_Master>();
		}
		
		void MeleeAttackActions()
		{
			myCollider.enabled = true;
			myRigidbody.isKinematic = false;
			myAnimator.SetTrigger("Attack");
		}
		
		void MeleeAttackComplete()
		{
			myCollider.enabled = false;
			myRigidbody.isKinematic = true;
			meleeMaster.isInUse = false;
		}
    }
}

