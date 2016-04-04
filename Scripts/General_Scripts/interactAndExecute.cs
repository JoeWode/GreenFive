using UnityEngine;
using System.Collections;
using Fungus;

public class interactAndExecute : MonoBehaviour {

	public Material matStart;
	public Material outline;
	private Renderer rend;
	private bool selected;
	public Flowchart flowchart;
	public string block;

	void Start () {
		rend = GetComponentInChildren<Renderer> ();
		rend.material = matStart;
		selected = false;
	}

	void Update () {
		if (selected && Input.GetKey (KeyCode.Q)) {
			flowchart.ExecuteBlock (block);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "FPSController_ALFDP") {
			rend.material = outline;
			selected = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.gameObject.name == "FPSController_ALFDP") {
			rend.material = matStart;
			selected = false;
		}
	}
}
