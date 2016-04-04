using UnityEngine;
using System.Collections;

public class cameraZoom : MonoBehaviour {

	public float baseFOV = 70.0f;
	public float zoomFOV = 25.0f;
	public float zoomSmooth = 4.0f;
	public bool zoom = false;
	private float currentFOV;
	public Camera cam;

	// Use this for initialization
	void Start () {
		currentFOV = cam.fieldOfView;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire2")) {
			zoom = true;
		} else {
			zoom = false;
		}

		if (zoom) {
			currentFOV = Mathf.Lerp(currentFOV, zoomFOV, Time.deltaTime * zoomSmooth);
			cam.fieldOfView = currentFOV;
		} else {
			currentFOV = Mathf.Lerp(currentFOV, baseFOV, Time.deltaTime * zoomSmooth);
			cam.fieldOfView = currentFOV;
		}
	}
	
}
