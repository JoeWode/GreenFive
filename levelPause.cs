using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class levelPause : MonoBehaviour {

    /*
    This script is an extension for fungus. It's an alternative to adjusting the time scale as a method of pausing the game. This allows fungus to operate
    while player control is disabled and any animator or particle system components given the appopriate tags will be paused. The script generates lists
    of tagged objects and lists of the associated components. It then iterates through these lists and toggles those components on and off. The function
    calls are made inside fungus blocks.
    */
    
    public GameObject[] lvlobj; //Reference to the list of gameobjects with animator components to be disabled.
    public Animator[] anims; //Reference to the list of animator components generated from the previous list.
    public GameObject[] partsys; //Reference to the list of gameobjects with particle system components.
    public ParticleSystem[] parts; //Reference to the list of particle system components generated from the previous list.
    public GameObject rig; //Reference to the FPSContoller prefab.
    FirstPersonController player; //Reference to the FPSController script.

    void Start () {
	lvlobj = GameObject.FindGameObjectsWithTag ("pausable"); //Populates the list with tagged objects.
        partsys = GameObject.FindGameObjectsWithTag("Particles"); //Populates the list with tagged objects.

        rig = GameObject.FindGameObjectWithTag("Player"); //Assigns the FPSController by finding it's tag.
        player = rig.GetComponent<FirstPersonController>(); //Assigns the FPSController script.
        player.enabled = true; //Makes Sure FPSController script is active at start.
        Cursor.lockState = CursorLockMode.Locked; //Locks cursor.
        Cursor.visible = false; //Cursor visibility off.

        anims = new Animator[lvlobj.Length]; //Creates a new list of animator components equal in length to the lvlobj list, and populates the list with the animator components attatched to each gameobject in the lvlobjs list.
		for (int i = 0; i < lvlobj.Length; i++) {
			anims[i] = lvlobj[i].GetComponent<Animator>();
		}
		
		foreach (Animator anim in anims) { //Makes sure the animators are currently active at start.
			anim.enabled = true; 
		}

        parts = new ParticleSystem[partsys.Length]; //Creates a new list of particle system components equal in length to the partsys list, and populates it particle system components from the gameobjects in the partsys list.
        for (int i = 0; i < partsys.Length; i++)
        {
            parts[i] = partsys[i].GetComponent<ParticleSystem>();
        }
    }

	public void AnimOff() { //This function turns off all animator and particle system components in parts[] and anims[], disables the FPSController script, and enables the cursor.
		foreach (Animator anim in anims) {
			anim.enabled = false; 
		}
        foreach (ParticleSystem part in parts)
        {
            part.Pause();
        }

        player.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

	public void AnimOn() { //This function enables all the animators and particle systems in parts[] and anims[], enables the FPSController script, and disables the cursor.
		foreach (Animator anim in anims) {
			anim.enabled = true; 
		}
        foreach (ParticleSystem part in parts)
        {
            part.Play();
        }

        player.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
