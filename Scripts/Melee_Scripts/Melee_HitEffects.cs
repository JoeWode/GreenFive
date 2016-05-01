using UnityEngine;
using System.Collections;

namespace G5
{
	public class Melee_HitEffects : MonoBehaviour 
	{

		private Melee_Master meleeMaster;
		public GameObject defaultHitEffect;
		public GameObject enemyHitEffect;

		void OnEnable()
		{
			SetInitialReferences();
			meleeMaster.EventHit += SpawnHitEffects;
		}

		void OnDisable()
		{
			meleeMaster.EventHit -= SpawnHitEffects;
		}


		void SetInitialReferences()
		{
			meleeMaster = GetComponent<Melee_Master>();
		}
		
		void SpawnHitEffects(Collision hitCollision, Transform hitTransform)
		{
			Quaternion quatAngle = Quaternion.LookRotation(hitCollision.contacts[0].normal);
			if(hitTransform.GetComponent<Enemy_TakeDamage>() != null)
			{
				Instantiate(enemyHitEffect, hitCollision.contacts[0].point, quatAngle);
			}
			else
			{
				Instantiate(defaultHitEffect, hitCollision.contacts[0].point, quatAngle);
			}
		}
    }
}

