using UnityEngine;
using System.Collections;

public class AOEWeapon : MonoBehaviour {

	/*
	This is a script for adding an area of effect to a weapon's raycast. A sphere cast is
	sent out from the raycast hit point, generating a list of all rigidbodies inside the
	radius and adding explosive force to all of them. This script also controls animation 
	on the weapon itself, a muzzle flash particle system, instantiating an impact particle
	system at the raycast hitpoint, and playing a sound clip. Explosive force, explosion
	radius, upwards modifier, forcemode, and fire rate can be adjusted in the editor.
	*/
	
	public float force = 100.0f;
	public float radius = 2.0f;
	public float upwardsModifier = 2.0f;
	public ForceMode forceMode;
	public float fireRate = 0.5F;
	private float nextFire = 0.0F;
	public GameObject muzzleFlashParticles;
	ParticleSystem muzzleFlash;
	public GameObject impactParticles;
	Animator anim;
	AudioSource shotSound;
	
	void Start () {
		anim = GetComponentInChildren<Animator>();
		shotSound = GetComponent<AudioSource>();
		muzzleFlash = muzzleFlashParticles.GetComponent<ParticleSystem>();
		muzzleFlash.Stop();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			StopCoroutine ("Fire");
			StartCoroutine ("Fire");
			anim.SetTrigger("Shoot");
			muzzleFlash.Play();
			shotSound.Play();
		} else {
			muzzleFlash.Stop();
		}
	}
	
	IEnumerator Fire() {
		while (Input.GetButtonDown ("Fire1")) {		
			Ray ray = new Ray(transform.position, transform.forward);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100)) {
				if (hit.collider) {
					Collider[] colliders = Physics.OverlapSphere(hit.point, radius);
					foreach(Collider col in colliders) {
						Rigidbody rb = col.GetComponent<Rigidbody>();		
						if (rb != null){
							rb.AddExplosionForce(force, hit.point, radius, upwardsModifier, forceMode);
						}
					}
				}
			}	
			if (hit.collider) {
				Instantiate(impactParticles, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
				//hit.collider.SendMessageUpwards ("", SendMessageOptions.DontRequireReceiver);
			}			
			yield return null;
		}
	}
}
