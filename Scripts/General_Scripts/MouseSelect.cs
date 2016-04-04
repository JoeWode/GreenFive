using UnityEngine;
using System.Collections;
using Fungus;

public class MouseSelect : MonoBehaviour {

    /*
    This script uses Vector3.Distance to determine the proximity between the player and a given object. Once the player is within active distance
    and mouses over the object the material will change to indicate object interactibility. This script is an extension for Fungus meant to activate standalone blocks.
    */
    
    GameObject player; //Reference to the FPSController.
    public Material matStart; //Reference to the initial material.
    public Material outline; //Reference to the "highlighted" material.
    private Renderer rend; //Reference to the mesh renderer component.
    public bool selectable = false; //This bool is flipped when the player enters the active distance of the object. It controls whether the object can be interacted with and/or highlighted.
    public bool selected = false; // This bool is flipped when the player is with active distance of the object and has moused over the object. It allows the object to be activated.
    public Flowchart flowchart; //Reference to the flowchart containing the block to be executed.
    public float objDistance; //Variable storing the distance between the player and the object.
    public float activeDistance = 6.0f; //The distance the player must be within to highlight and activate the object.
    public string block; //A string referencing the block to be executed.


    void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); //Assigns the FPSController by finding its tag.
        rend = GetComponentInChildren<Renderer>(); //Assigns the mesh renderer component.
    }
	
    void Update () {
        objDistance = Vector3.Distance(player.transform.position, transform.position); //Determines the distance between the player and the object.

        if (objDistance < activeDistance) //If the player enters the active distance the object becomes selectable, and can be highlighted by mousing over it.
        {
            selectable = true;
        }
        else {
            selectable = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && selected) {
            flowchart.ExecuteBlock(block); //If the object is highlighted the referenced block can be activated by pressing Q.
            if (gameObject.tag == "consumable") { //If the object is a consumable (i.e. a health pick-up) the object is destroyed.
                Destroy(gameObject, 0.2f);
            }
        }
    }

    void OnMouseEnter() { //If the player is within active distance mousing over will highlight the object by switching it's material.
        if (selectable)
        {
            rend.material = outline;
            selected = true; //The highlighted object can then be activated.
        }
        else {
            rend.material = matStart;
            selected = false;
        }
    }

    void OnMouseExit() {
        rend.material = matStart;
        selected = false;
    }
}

/*
Though this script is executing fungus blocks it can easily be modified for all sorts of object interactibility like activating switches, opening doors, etc.
*/
