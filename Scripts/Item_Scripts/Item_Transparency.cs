using UnityEngine;
using System.Collections;

namespace G5
{
	public class Item_Transparency : MonoBehaviour 
	{

		private Item_Master itemMaster;
		public Material transparentMat;
		private Material defaultMat;

		void OnEnable()
		{
			SetInitialReferences();
			itemMaster.EventObjectPickup += SetToTransparentMaterial;
			itemMaster.EventObjectThrow += SetToDefaultMaterial;
		}

		void OnDisable()
		{
			itemMaster.EventObjectPickup -= SetToTransparentMaterial;
			itemMaster.EventObjectThrow -= SetToDefaultMaterial;
		}

		void Start() 
		{
			CaptureStartingMaterial();
		}

		void SetInitialReferences()
		{
			itemMaster = GetComponent<Item_Master>();
		}
		
		void CaptureStartingMaterial()
		{
			defaultMat = GetComponent<Renderer>().material;
		}
		
		void SetToDefaultMaterial()
		{
			GetComponent<Renderer>().material = defaultMat;
		}
		
		void SetToTransparentMaterial()
		{
			GetComponent<Renderer>().material = transparentMat;
		}
    }
}

