using UnityEngine;
using System.Collections;

namespace G5
{
	public class Enemy_Health : MonoBehaviour 
	{

		private Enemy_Master enemyMaster;
		public int enemyHealth = 100;
		public int healthLow = 25;

		void OnEnable()
		{
			SetInitialReferences();
			enemyMaster.EventEnemyDeductHealth += DeductHealth;
			enemyMaster.EventEnemyIncreaseHealth += IncreaseHealth;
		}

		void OnDisable()
		{
			enemyMaster.EventEnemyDeductHealth -= DeductHealth;
			enemyMaster.EventEnemyIncreaseHealth -= IncreaseHealth;
		}

		void SetInitialReferences()
		{
			enemyMaster = GetComponent<Enemy_Master>();
		}
		
		void DeductHealth(int healthChange)
		{
			enemyHealth -= healthChange;
			if(enemyHealth <= 0)
			{
				enemyHealth = 0;
				enemyMaster.CallEventEnemyDie();
				Destroy(gameObject, Random.Range(10, 20));
			}
			
			CheckHealthFraction();
		}
		
		void CheckHealthFraction()
		{
			if(enemyHealth <= healthLow && enemyHealth > 0)
			{
				enemyMaster.CallEventEnemyHealthLow();
			}
			else if(enemyHealth > healthLow)
			{
				enemyMaster.CallEventEnemyHealthRecovered();
			}
		}
		
		void IncreaseHealth(int healthChange)
		{
			enemyHealth += healthChange;
			
			if(enemyHealth > 100)
			{
				enemyHealth = 100;
			}
			
			CheckHealthFraction();
		}
    }
}

