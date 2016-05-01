using UnityEngine;
using System.Collections;

namespace G5
{
	public class Melee_Strike : MonoBehaviour 
	{

		private Melee_Master meleeMaster;
		private float nextSwingTime;
		public float damage = 25;

		void Start() 
		{
			SetInitialReferences();
		}

		void OnCollisionEnter(Collision collision) 
		{
			if(collision.gameObject != GameManager_References._player && meleeMaster.isInUse && Time.time > nextSwingTime)
			{
				nextSwingTime = Time.time + meleeMaster.swingRate;
				collision.transform.SendMessage("ProcessDamage", damage, SendMessageOptions.DontRequireReceiver);
				meleeMaster.CallEventHit(collision, collision.transform);
			}
		}

		void SetInitialReferences()
		{
			meleeMaster = GetComponent<Melee_Master>();
		}
    }
}

