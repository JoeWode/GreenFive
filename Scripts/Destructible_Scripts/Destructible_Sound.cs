using UnityEngine;
using System.Collections;

namespace G5
{
	public class Destructible_Sound : MonoBehaviour 
	{

		private Destructible_Master destructibleMaster;
		public float explosionVolume = 0.5f;
		public AudioClip explosionSound;

		void OnEnable()
		{
			SetInitialReferences();
			destructibleMaster.EventDestroyMe += PlayExplosionSound;
		}

		void OnDisable()
		{
			destructibleMaster.EventDestroyMe -= PlayExplosionSound;
		}

		void SetInitialReferences()
		{
			destructibleMaster = GetComponent<Destructible_Master>();
		}
		
		void PlayExplosionSound()
		{
			if(explosionSound != null)
			{
				AudioSource.PlayClipAtPoint(explosionSound, transform.position, explosionVolume);
			}
		}
    }
}

