using UnityEngine;
using System.Collections;

namespace G5
{
	public class Destructible_ActivateShards : MonoBehaviour 
	{

		private Destructible_Master destructibleMaster;
		public string shardLayer = "Ignore Raycast";
		public GameObject shards;
		public bool shouldShardsDissappear;
		private float myMass;
		

		void OnEnable()
		{
			SetInitialReferences();
			destructibleMaster.EventDestroyMe += ActivateShards;
		}

		void OnDisable()
		{
			destructibleMaster.EventDestroyMe -= ActivateShards;
		}

		void SetInitialReferences()
		{
			destructibleMaster = GetComponent<Destructible_Master>();
			
			if(GetComponent<Rigidbody>() != null)
			{
				myMass = GetComponent<Rigidbody>().mass;
			}
		}
		
		void ActivateShards()
		{
			if(shards != null)
			{
				shards.transform.parent = null;
				shards.SetActive(true);
				
				foreach(Transform shard in shards.transform)
				{
					shard.tag = "Untagged";
					shard.gameObject.layer = LayerMask.NameToLayer(shardLayer);
					
					shard.GetComponent<Rigidbody>().AddExplosionForce(myMass, transform.position, 40, 0, ForceMode.Impulse);
					
					if(shouldShardsDissappear)
					{
						Destroy(shard.gameObject, 10);
					}
				}
			}
		}
    }
}

