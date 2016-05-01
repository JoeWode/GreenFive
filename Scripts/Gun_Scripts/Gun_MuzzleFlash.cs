using UnityEngine;
using System.Collections;

namespace G5
{
	public class Gun_MuzzleFlash : MonoBehaviour 
	{
	
		public ParticleSystem muzzleFlash;
		private Gun_Master gunMaster;

		void OnEnable()
		{
			SetInitialReferences();
			gunMaster.EventPlayerInput += PlayMuzzleFlash;
		}

		void OnDisable()
		{
			gunMaster.EventPlayerInput -= PlayMuzzleFlash;
		}

		void SetInitialReferences()
		{
			gunMaster = GetComponent<Gun_Master>();
		}
		
		void PlayMuzzleFlash()
		{
			if(muzzleFlash != null)
			{
				muzzleFlash.Play();
			}
		}
    }
}

