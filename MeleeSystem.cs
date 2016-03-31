using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

	/*
	This is a script for enabling a melee attack system on an FPSController. It uses Raycasting to add force to rigidbodies.
	It also can broadcast a message to any script attached to the collider the raycast hit strikes. The script controls an animation
	on a melee weapon object and times the raycast to coincide with when the animation reaches the apex of its swing.
	The script also plays a "swinging" sound and switches this clip to an "impact" sound if it strikes a collider.
	The script will also instantiate a particle system at the raycast hit point.
	This script is meant to be attached to a null object positioned slightly in front of the FPSController's secondary camera. 
	It needs to be outside the FPSController's collider.
	The melee weapon is then parented to this null object so the script can find it's animator component.
	*/
	
	/* public LineRenderer line; A line renderer component is used to visually represent the timing and range of the raycast. This is not meant to be included in any builds.*/
	public GameObject impactParticlesMetal; //Reference to the particle system prefab instantiated on impact with a collider.
	public GameObject impactParticlesPlastic;
	public GameObject impactParticlesGlass;
	public GameObject impactParticlesFlesh;
	public AudioClip hitSoundMetal; //Reference to the audio clip used when the raycast hits a collider.
	public AudioClip hitSoundPlastic;
	public AudioClip hitSoundGlass;
	public AudioClip hitSoundFlesh;
	public AudioClip swingSound; //Reference to the audio clip played at the beginning of the coroutine.
	public AudioSource audioPlayer; //Reference to the audio player component.
	public Animator anim; //Reference to the melee weapon's animator component.

	void Start() {
		//line = GetComponent<LineRenderer> (); //Assigning the line renderer. Remove the component and this line at build.
		//line.enabled = false; //Disabling the line renderer. Remove this line at build.
		audioPlayer = GetComponent<AudioSource> (); //Assigning the audio component.
		anim = GetComponentInChildren<Animator>(); //Assigning the animator component.
	}

	void Update () { //Watch for left mouse down.
		if (Input.GetButtonDown ("Fire1")) {
			StopCoroutine ("Swing"); //Make sure the couroutine is disabled.
			StartCoroutine ("Swing"); //Since the raycast is being delayed slightly to match the weapon animation the raycast is being handled inside a coroutine.
			anim.SetTrigger("swing"); //Trigger the animation on the melee weapon.
		}
	}

	IEnumerator Swing() {
		//line.enabled = true; //enables the line renderer component. Remove this line at build.
		
		audioPlayer.clip = swingSound; //Sets audio clip to the "swing" sound.
		audioPlayer.Play(); //Plays the audio clip.
		
		yield return new WaitForSeconds(0.2f); //Delays the raycast.

		Ray ray = new Ray(transform.position, transform.forward); //Casts a ray from the current position of the null object, forward.
		RaycastHit hit; //Stores raycast info.

		//line.SetPosition (0, ray.origin); //Uses the line renderer to create a visual representation of the raycast. Remove this line at build.

		if (Physics.Raycast(ray, out hit, 5)) { 
			//line.SetPosition(1, hit.point); //Shortens the line if it strikes a rigidbody.
			if (hit.rigidbody) {
				hit.rigidbody.AddForceAtPosition(transform.forward * 750, hit.point); //Adds force at the point of impact if the raycast strikes a rigidbody.
			}
		} 
		//else 
			//line.SetPosition (1, ray.GetPoint (5)); //Otherwise the line renderer will create a line representing the maximum range of the weapon. Remove this line at build.

		if (hit.collider.gameObject.tag == "metal") {
			/*hit.collider.SendMessageUpwards("", SendMessageOptions.DontRequireReceiver); If the raycast hits a collider it will transmit a function call to any script attached to any object in the hierarchy above the object whose colider was struck by the raycast. This function call turns of the animator component on a biped character and turns on its ragdoll component.*/
			Instantiate(impactParticlesMetal, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); //Instantiates a particle effect prefab at the raycast's point of impact.
			audioPlayer.clip = hitSoundMetal; //Assigns the "impact" sound to the audioplayer component.
			audioPlayer.Play(); //Plays the assigned clip.
		} else if (hit.collider.gameObject.tag == "plastic"){
			//hit.collider.SendMessageUpwards("", SendMessageOptions.DontRequireReceiver);
			Instantiate(impactParticlesPlastic, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); //Instantiates a particle effect prefab at the raycast's point of impact.
			audioPlayer.clip = hitSoundPlastic; //Assigns the "impact" sound to the audioplayer component.
			audioPlayer.Play(); //Plays the assigned clip.
		} else if (hit.collider.gameObject.tag == "glass"){
			//hit.collider.SendMessageUpwards("", SendMessageOptions.DontRequireReceiver);
			Instantiate(impactParticlesGlass, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); //Instantiates a particle effect prefab at the raycast's point of impact.
			audioPlayer.clip = hitSoundGlass; //Assigns the "impact" sound to the audioplayer component.
			audioPlayer.Play(); //Plays the assigned clip.
		} else if (hit.collider.gameObject.tag == "flesh"){
			//hit.collider.SendMessageUpwards("", SendMessageOptions.DontRequireReceiver);
			Instantiate(impactParticlesFlesh, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); //Instantiates a particle effect prefab at the raycast's point of impact.
			audioPlayer.clip = hitSoundFlesh; //Assigns the "impact" sound to the audioplayer component.
			audioPlayer.Play(); //Plays the assigned clip.
		} 
		yield return null;
		
		//line.enabled = false; //Disables the line renderer component. Remove this line at build.
	}
}

/*
This script is still a W.I.P. It needs a few things to round it out. I intend to add a second attack type (a 'thrust') with a seperate animation as well as the ability 
to block incoming damage. I also plan to add the ability to play different sounds and particle effects depending on what type of object or 'material'
is being struck(added). I also intend to add the ability to instantiate decals at the raycast hit so that each strike leaves a mark. These will also differ according to 'material'.
*/
