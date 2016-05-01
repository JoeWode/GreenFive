using UnityEngine;
using System.Collections;

namespace G5
{
	public class Gun_ApplyDamage : MonoBehaviour 
	{

		private Gun_Master gunMaster;
		public int damage = 10;

		void OnEnable()
		{
			SetInitialReferences();
			gunMaster.EventShotEnemy += ApplyDamage;
			gunMaster.EventShotDefault += ApplyDamage;
		}

		void OnDisable()
		{
			gunMaster.EventShotEnemy -= ApplyDamage;
			gunMaster.EventShotDefault -= ApplyDamage;
		}

		void SetInitialReferences()
		{
			gunMaster = GetComponent<Gun_Master>();
		}
		
		void ApplyDamage(Vector3 hitPosition, Transform hitTransform)
		{
			hitTransform.SendMessage("ProcessDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
    }
}

