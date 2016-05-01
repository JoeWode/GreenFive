using UnityEngine;
using System.Collections;
using Fungus;

namespace G5
{
    public class Item_StoryObject : MonoBehaviour 
    {
	
		public string fungusBlock;
		public Flowchart storyChart;
		private Item_Outline itemOutline;

		void OnEnable()
		{
			SetInitialReferences();
		}

		void SetInitialReferences()
		{
			itemOutline = GetComponent<Item_Outline>();
		}

		void Update()
		{
			CheckForActivationRequest();
		}

		void CheckForActivationRequest()
		{
			if(Input.GetButtonUp("Use") && itemOutline.isActive)
			{
				ActivateBlock();
			}
		}

		void ActivateBlock()
		{
			storyChart.ExecuteBlock(fungusBlock);
		}
    }
}

