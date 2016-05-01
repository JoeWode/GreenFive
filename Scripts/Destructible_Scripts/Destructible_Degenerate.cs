using UnityEngine;
using System.Collections;

namespace G5
{
	public class Destructible_Degenerate : MonoBehaviour 
	{

		private Destructible_Master destructibleMaster;
		private bool isHealthLow = false;
		public float degenRate = 1;
		private float nextDegenTime;
		public int healthLoss = 5;

		void OnEnable()
		{
			SetInitialReferences();
			destructibleMaster.EventHealthLow += HealthLow;
		}

		void OnDisable()
		{
			destructibleMaster.EventHealthLow -= HealthLow;
		}
		
		void Update() 
		{
			CheckIfHealthShouldDegenerate();
		}

		void SetInitialReferences()
		{
			destructibleMaster = GetComponent<Destructible_Master>();
		}
		
		void HealthLow()
		{
			isHealthLow = true;
		}
		
		void CheckIfHealthShouldDegenerate()
		{
			if(isHealthLow)
			{
				if(Time.time > nextDegenTime)
				{
					nextDegenTime = Time.time + degenRate;
					destructibleMaster.CallEventDeductHealth(healthLoss);
				}
			}
		}
    }
}

