using UnityEngine;
using System.Collections;

namespace G5
{
	public class Destructible_Health : MonoBehaviour 
	{

		private Destructible_Master destructibleMaster;
		public int health;
		private int startingHealth;
		private bool isExploding = false;

		void OnEnable()
		{
			SetInitialReferences();
			destructibleMaster.EventDeductHealth += DeductHealth;
		}

		void OnDisable()
		{
			destructibleMaster.EventDeductHealth -= DeductHealth;
		}

		void SetInitialReferences()
		{
			destructibleMaster = GetComponent<Destructible_Master>();
			startingHealth = health;
		}
		
		void DeductHealth(int healthToDeduct)
		{
			health -= healthToDeduct;
			
			CheckIfHealthLow();
			
			if(health <= 0 && !isExploding)
			{
				isExploding = true;
				destructibleMaster.CallEventDestroyMe();
			}
		}
		
		void CheckIfHealthLow()
		{
			if(health <= startingHealth / 2)
			{
				destructibleMaster.CallEventHealthLow();
			}
		}
    }
}

