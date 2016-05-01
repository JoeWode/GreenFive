using UnityEngine;
using System.Collections;

namespace G5
{
	public class Item_CyberspaceTerminal : MonoBehaviour 
	{

		private GameManager_CyberSpaceToggle cyberToggle;
		public Player_DetectItem playerDetectItem;

		void OnEnable()
		{
			SetInitialReferences();
		}

		void SetInitialReferences()
		{
			cyberToggle = GameObject.Find("GameManager").GetComponent<GameManager_CyberSpaceToggle>();
		}
		
		void OnTriggerEnter()
		{
			cyberToggle.canHack = true;
		}
		
		void OnTriggerExit()
		{
			cyberToggle.canHack = false;
		}
    }
}

