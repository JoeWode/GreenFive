using UnityEngine;
using System.Collections;
using Fungus;

namespace G5
{
	public class NPC_DialogueActivation : MonoBehaviour 
	{

		public string fungusBlock;
		public Flowchart storyChart;
		public GameObject player;
		private float playerDistance;
		public float activeDistance = 8;
		public float headLookDistance = 16;
		public bool isProximate = false;
		public bool isVisible = false;
		public HeadLookController headLookController;
		public float invokeSpeed = 0.01f;
		public float smoothAmount = 0.1f;

		void Update() 
		{
			playerDistance = Vector3.Distance(player.transform.position, transform.position);
			
			if(playerDistance <= activeDistance)
			{
				isProximate = true;
			}
			else
			{
				isProximate = false;
			}
			
			if(playerDistance <= headLookDistance)
			{
				isVisible = true;
			}
			else
			{
				isVisible = false;
			}
			
			CheckForActivationRequest();
			CheckEffectValue();
		}

		void CheckForActivationRequest()
		{
			if(isProximate && Input.GetButtonUp("Use"))
			{
				ActivateDialogueBlock();
			}
		}
		
		void ActivateDialogueBlock()
		{
			storyChart.ExecuteBlock(fungusBlock);
		}
		
		void CheckEffectValue()
		{
			if(isVisible)
			{
				if(headLookController.effect < 1 && !IsInvoking("IncreaseEffect"))
				{
					Invoke("IncreaseEffect", invokeSpeed);
				}
			}
			else
			{
				if(headLookController.effect > 0 && !IsInvoking("DecreaseEffect"))
				{
					Invoke("DecreaseEffect", invokeSpeed);
				}
			}
		}
		
		void IncreaseEffect()
		{
			headLookController.effect += smoothAmount;
		}
		
		void DecreaseEffect()
		{
			headLookController.effect -= smoothAmount;
		}
    }
}

