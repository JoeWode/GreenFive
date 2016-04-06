using UnityEngine;
using System.Collections;

namespace G5
{
    public class Item_Name : MonoBehaviour 
    {
    	
    	public string itemName;
    	
    	void Start() 
    	{
    	    SetItemName();
    	}

    	void SetItemName() 
    	{
    	    transform.name = itemName;
    	}
    }
}

