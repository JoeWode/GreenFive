using UnityEngine;
using System.Collections;

public class lightFlicker : MonoBehaviour {

	/*
	This is a simple script to create a flickering light source. Useful for fire or even light bleeding from a monitor.
	Simply place on your light and adjust your values in the editor.
	*/
	
	public float minIntensity = 1.5f;
	public float maxIntensity = 8.0f;
	private Light light;
	private float random;
	public float flickerTime = 0.3f;


	void Start () {
		light = GetComponent<Light> ();
		InvokeRepeating ("Flicker", flickerTime, flickerTime);
	}

	void Flicker() {
		random = Random.Range (minIntensity, maxIntensity);
		light.intensity = random;
	}
}
