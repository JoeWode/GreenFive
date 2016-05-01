using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Outline : MonoBehaviour 
    {
	
		private Item_Master itemMaster;
		public Renderer myRenderer;
		public Material defaultMaterial;
		public Material outlineMaterial;
		public float outlineDistance = 6.0f;
		public bool isActive = false;
		public Player_DetectItem playerDetectItem;

		void OnEnable()
		{
			SetInitialReferences();
			itemMaster.EventObjectInProximity += ToggleMaterials;
		}

		void OnDisable()
		{
			itemMaster.EventObjectInProximity -= ToggleMaterials;
		}

		void SetInitialReferences()
		{
			itemMaster = GetComponent<Item_Master>();
			if (GetComponent<Renderer>() != null)
			{
				myRenderer = GetComponent<Renderer>();
			}
			else 
			{
				myRenderer = GetComponentInChildren<Renderer>();
			}
			
			myRenderer.material = defaultMaterial;
		}

		void ToggleMaterials()
		{
			if(playerDetectItem.isProximate)
			{
				myRenderer.material = outlineMaterial;
				isActive = true;
			}
			else
			{
				myRenderer.material = defaultMaterial;
				isActive = false;
			}
		}
    }
}

