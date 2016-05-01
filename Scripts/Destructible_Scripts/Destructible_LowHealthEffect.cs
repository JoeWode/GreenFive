using UnityEngine;
using System.Collections;

namespace G5
{
	public class Destructible_LowHealthEffect : MonoBehaviour 
	{

		private Destructible_Master destructibleMaster;
		public GameObject[] lowHealthEffects;

		void OnEnable()
		{
			SetInitialReferences();
			destructibleMaster.EventHealthLow += TurnOnLowHealthEffect;
		}

		void OnDisable()
		{
			destructibleMaster.EventHealthLow -= TurnOnLowHealthEffect;
		}

		void SetInitialReferences()
		{
			destructibleMaster = GetComponent<Destructible_Master>();
		}
		
		void TurnOnLowHealthEffect()
		{
			if(lowHealthEffects.Length > 0)
			{
				for(int i = 0; i < lowHealthEffects.Length; i++)
				{
					lowHealthEffects[i].SetActive(true);
				}
			}
		}
    }
}

